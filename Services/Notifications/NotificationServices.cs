
namespace SinglePaymentAPI.Services.Notifications
{
    public class NotificationServices : INotificationServices
    {
        public async Task SendNotification()
        {
            await Task.Delay(1500);
            Console.WriteLine("Client Notified");
        }
    }
}
