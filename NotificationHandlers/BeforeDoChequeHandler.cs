using Resto.Front.Api.Data.Orders;
using Resto.Front.Api.UI;


namespace Resto.Front.Api.SamplePlugin.NotificationHandlers
{
    public class BeforeDoChequeHandler : BaseNotificationHandler
    {
        public BeforeDoChequeHandler()
        {
            subscription = PluginContext.Notifications.BeforeDoCheque.Subscribe(x => OnBeforeDoCheque(x.order, x.os, x.vm));
        }

        public void OnBeforeDoCheque(IOrder order, IOperationService os, IViewManager vm)
        {
            PluginContext.Log.Info("BeforeDoCheque");
            PluginContext.Log.InfoFormat("Order Info: {0}\nOS: {1}\nVM:{2}", ConvertToJson(order), ConvertToJson(os), ConvertToJson(vm));
        }
    }
}
