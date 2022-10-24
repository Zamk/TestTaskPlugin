using Resto.Front.Api.Attributes.JetBrains;
using Resto.Front.Api.Data.Orders;
using Resto.Front.Api.UI;


namespace Resto.Front.Api.SamplePlugin.NotificationHandlers
{
    public class BeforeOrderBillHandler : BaseNotificationHandler
    {
        public BeforeOrderBillHandler()
        {
            subscription = PluginContext.Notifications.BeforeOrderBill.Subscribe(x => OnBeforeOrderBill(x.order, x.os, x.vm));
        }

        public void OnBeforeOrderBill([NotNull] IOrder order, [NotNull] IOperationService os, [CanBeNull] IViewManager vm)
        {
            PluginContext.Log.Info("BeforeOrderBill");
            PluginContext.Log.InfoFormat("Order Info: {0}\nOS: {1}\nVM: {2}", ConvertToJson(order), ConvertToJson(os), ConvertToJson(vm));
        }

    }
}
