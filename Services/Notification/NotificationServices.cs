
namespace BancoCem.Services.Notification
{
    public class NotificationServices : INotificationServices
    {
        public async Task SendNotificationAsync()
        {
            await Task.Delay(2000);
            Console.WriteLine("O Cliente foi notificado com sucesso!");
        }
    }
}
