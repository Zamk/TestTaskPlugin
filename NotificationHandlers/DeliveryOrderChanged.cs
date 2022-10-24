using System;
using System.Threading;
using Resto.Front.Api.Data.Orders;
using Resto.Front.Api.Data.Brd;


namespace Resto.Front.Api.SamplePlugin.NotificationHandlers
{
    public class DeliveryOrderChangedHandler : BaseNotificationHandler
    {
        public DeliveryOrderChangedHandler()
        {
            subscription = PluginContext.Notifications.DeliveryOrderChanged.Subscribe(x => OnDeliveryOrderChanged(x.Entity));
        }

        public void OnDeliveryOrderChanged(IDeliveryOrder deliveryOrder)
        {
            PluginContext.Log.Info("DeliveryOrderChanged");
            PluginContext.Log.InfoFormat("DeliveryOrder Info: {0}", ConvertToJson(deliveryOrder));

            if (deliveryOrder.DeliveryStatus == DeliveryStatus.OnWay)
            {
                string message = "Доставка №" + deliveryOrder.Number + "в пути.\nВремя оплаты: " + deliveryOrder.BillTime.ToString() + "\nТекущее время: " + DateTime.Now.ToString();
                Wpf.NotificationThread notificationThread = new Wpf.NotificationThread(message);

                var windowThread = new Thread(notificationThread.Start);
                windowThread.SetApartmentState(ApartmentState.STA);
                windowThread.Start();
            }
        }
    }
}
