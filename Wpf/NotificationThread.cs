using System.Threading;


namespace Resto.Front.Api.SamplePlugin.Wpf
{
    public class NotificationThread
    {
        public string Message { get; set; }

        public NotificationThread(string message)
        {
            Message = message;
        }

        public void Start()
        {
            Wpf.DeliveryOnWayNotification notification = new Wpf.DeliveryOnWayNotification();
            notification.DeliveryInfo.Text = Message;
            notification.Show();
            Thread.Sleep(10 * 1000);
            notification.Close();
        }
    }
}
