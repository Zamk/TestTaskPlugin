using System;
using Newtonsoft.Json;
using System.Runtime.Remoting;


namespace Resto.Front.Api.SamplePlugin.NotificationHandlers
{
    public class BaseNotificationHandler : IDisposable
    {
        protected IDisposable subscription;

        public string ConvertToJson(Object value)
        {
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }).ToString();
            }
            catch (Exception ex)
            {
                PluginContext.Log.Error("Ошибка при дессериализации");
                PluginContext.Log.Error(ex.Message);
            }

            return json;
        }

        public void Dispose()
        {
            try
            {
                subscription.Dispose();
            }
            catch (RemotingException)
            {
                // nothing to do with the lost connection
            }
        }
    }
}
