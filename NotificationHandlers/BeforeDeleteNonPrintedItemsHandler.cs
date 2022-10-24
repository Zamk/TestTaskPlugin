using System.Collections.Generic;
using Resto.Front.Api.Data.Orders;
using Resto.Front.Api.Data.Security;
using Resto.Front.Api.UI;


namespace Resto.Front.Api.SamplePlugin.NotificationHandlers
{
    public class BeforeDeleteNonPrintedItemsHandler : BaseNotificationHandler
    {
        public BeforeDeleteNonPrintedItemsHandler()
        {
            subscription = PluginContext.Notifications.BeforeDeleteNonPrintedItems.Subscribe(x => OnBeforeDeleteNonPrintedItems(x.order, x.deletingItems, x.deletingModifiers, x.user, x.vm));
        }

        public void OnBeforeDeleteNonPrintedItems(IOrder order, IReadOnlyCollection<IOrderRootItem> orderRootItems,
                                                    IReadOnlyCollection<IOrderModifierItem> orderModifierItems, IUser user, IViewManager vm)
        {
            PluginContext.Log.Info("BeforeDeleteNonPrintedItems");
            PluginContext.Log.InfoFormat("Order Info: {0}\nDeletedItems: {1}\nDeleted Modifiers: {2}\nUser: {3}\nVm: {4}",
                ConvertToJson(order), ConvertToJson(orderRootItems), ConvertToJson(orderModifierItems), ConvertToJson(user), ConvertToJson(vm));
        }
    }
}
