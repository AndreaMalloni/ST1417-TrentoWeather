using System.ServiceModel;
using static TrentoWeather_SOAP.Models.models;

namespace TrentoWeather_SOAP.Logic
{
    public class ServiceLogic
    {
        [ServiceContract]
        public interface ISoapService
        {
            [OperationContract]
            Giorni[] GetWeather(string? day = null);
        }

        public class SoapService : ISoapService
        {
            public Giorni[] GetWeather(string? day = null)
            {
                throw new NotImplementedException();
            }
        }
    }
}
