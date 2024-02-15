using System.ServiceModel;
using WeatherModels;
using static TrentoWeather_SOAP.Models.models;

namespace TrentoWeather_SOAP.Logic
{
    public class ServiceLogic
    {
        [ServiceContract]
        public interface ISoapService
        {
            [OperationContract]
            Giorni[] GetWeather();

            [OperationContract]
            Giorni[] GetWeatherByDay(DateTime day);
        }

        public class SoapService : ISoapService
        {
            public Giorni[] GetWeather()
            {
                weather_request request = new weather_request();
                Rootobject weather = request.send();
                return weather.previsione[0].giorni;
            }

            public Giorni[] GetWeatherByDay(DateTime day)
            {
                weather_request request = new weather_request();
                Rootobject weather = request.send();
                Giorni[] dayData = weather.previsione[0].giorni;
                return dayData.Where(d => d.giorno.Contains(day.Date.ToString("yyyy-MM-dd"))).ToArray();
            }
        }
    }
}
