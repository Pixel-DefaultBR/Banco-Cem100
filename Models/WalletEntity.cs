using BancoCem.Models.Enum;

namespace BancoCem.Models
{
    public class WalletEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string CPFCNPJ { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public decimal AccountBalance { get; set; }
        public UserType UserType { get; set; } = UserType.User;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public WalletEntity(string fullName, string cpfcnpj, string email, string password,
            UserType userType, decimal accountBalance = 0)
        {
            FullName = fullName;
            CPFCNPJ = cpfcnpj;
            Email = email;
            Password = password;
            UserType = userType;
            AccountBalance = accountBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Valor do deposito deve ser maior que zero.");
            AccountBalance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Valor do saque deve ser maior que zero.");
            if (amount > AccountBalance)
                throw new InvalidOperationException("Saldo insuficiente para realizar o saque.");
            AccountBalance -= amount;
        }
        public void Transfer(WalletEntity recipient, decimal amount)
        {
            if (recipient == null)
                throw new ArgumentNullException(nameof(recipient), "Destinatário não pode ser nulo.");
            if (amount <= 0)
                throw new ArgumentException("Valor da transferência deve ser maior que zero.");
            if (amount > AccountBalance)
                throw new InvalidOperationException("Saldo insuficiente para realizar a transferência.");

            recipient.Deposit(amount);
        }
        public void Credit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Valor do crédito deve ser maior que zero.");
            AccountBalance -= amount;
        }

        private WalletEntity() { }
    }
}
