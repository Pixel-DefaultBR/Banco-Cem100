using BancoCem.Database.Repository.Transferences;
using BancoCem.Database.Repository.Wallets;
using BancoCem.DTOs;
using BancoCem.Mappers;
using BancoCem.Models;
using BancoCem.Models.Requests;
using BancoCem.Models.Responses;
using BancoCem.Services.Authorizator;
using BancoCem.Services.Notification;

namespace BancoCem.Services.Transference
{
    public class TransferenceServices : ITransferenceServices
    {
        private readonly ITransferenceRepository _transferenceRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly IAuthorizatorServices _authorizatorService;
        private readonly INotificationServices _notificationService;

        public TransferenceServices(ITransferenceRepository transferenceRepository, IWalletRepository walletRepository,
            IAuthorizatorServices autorizatorService, INotificationServices notificationService)
        {
            _transferenceRepository = transferenceRepository;
            _walletRepository = walletRepository;
            _authorizatorService = autorizatorService;
            _notificationService = notificationService;
        }

        public async Task<Result<TransferenceDTO>> ExecuteAsync(TransferenceRequest request)
        {
            if (await _authorizatorService.AuthorizeAsync() == false)
            {
                return Result<TransferenceDTO>.Failure("A autorização falhou.");
            }

            var payer = await _walletRepository.GetByIdAsync(request.SenderId);
            var receiver = await _walletRepository.GetByIdAsync(request.RecipientId);

            if (payer == null || receiver == null)
            {
                return Result<TransferenceDTO>.Failure("Carteira não encontrada.");
            }

            if (payer.AccountBalance < request.Amount || payer.AccountBalance == 0)
            {
                return Result<TransferenceDTO>.Failure("Saldo insuficiente.");
            }

            payer.Transfer(receiver, request.Amount);
            payer.Credit(request.Amount);

            var transference = new TransferenceEntity(payer.Id, payer,
                receiver.Id, receiver, request.Amount);

            using (var transferecenScope = await _transferenceRepository.BeginTransferAsync())
            {
                try
                {
                    var updateTasks = new List<Task>
                    {
                        _walletRepository.UpdateAsync(payer),
                        _walletRepository.UpdateAsync(receiver),
                        _transferenceRepository.AddAsync(transference)
                    };

                    await Task.WhenAll(updateTasks);

                    await _transferenceRepository.CommitAsync();
                    await _walletRepository.CommitAsync();

                    await transferecenScope.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transferecenScope.RollbackAsync();

                    return Result<TransferenceDTO>.Failure($"Erro ao processar a transferência.");
                }
            }
            await _notificationService.SendNotificationAsync();
            return Result<TransferenceDTO>.Success(transference.TransferenceDTO());
        }
    }
}
