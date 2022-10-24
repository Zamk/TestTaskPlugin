using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using Resto.Front.Api.SamplePlugin.Properties;
using Resto.Front.Api.Attributes;
using Resto.Front.Api.Attributes.JetBrains;


namespace Resto.Front.Api.SamplePlugin
{ 
    [UsedImplicitly]
    [PluginLicenseModuleId(21005108)]
    public sealed class SamplePlugin : IFrontPlugin
    {
        private readonly Stack<IDisposable> subscriptions = new Stack<IDisposable>();

        public SamplePlugin()
        {
            PluginContext.Log.Info("Initializing SamplePlugin");

            subscriptions.Push(new NotificationHandlers.BeforeOrderBillHandler());
            subscriptions.Push(new NotificationHandlers.BeforeDeleteNonPrintedItemsHandler());
            subscriptions.Push(new NotificationHandlers.BeforeDoChequeHandler());
            subscriptions.Push(new NotificationHandlers.DeliveryOrderChangedHandler());

            PluginContext.Log.Info("SamplePlugin started");
        }

        public void Dispose()
        {
            while (subscriptions.Any())
            {
                var subscription = subscriptions.Pop();
                try
                {
                    subscription.Dispose();
                }
                catch (RemotingException)
                {
                    // nothing to do with the lost connection
                }
            }

            PluginContext.Log.Info("SamplePlugin stopped");
        }
    }
}