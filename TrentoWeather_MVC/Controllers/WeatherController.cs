using Microsoft.AspNetCore.Mvc;
using TrentoWeather_MVC.ViewModels;
using ServiceReference1;

namespace TrentoWeather_MVC.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index(DateTime? day)
        {
            Giorni[] serviceResults;
            WeatherIndexViewModel viewModel;

            try
            {
                ISoapService soapServiceChannel = new SoapServiceClient(SoapServiceClient.EndpointConfiguration.BasicHttpBinding_ISoapService_soap, "http://trentoweather_soap:80/Service.wsdl");

                if (day != null)
                {
                    serviceResults = soapServiceChannel.GetWeatherByDayAsync(day.Value).Result;
                }
                else
                {
                    serviceResults = soapServiceChannel.GetWeatherAsync().Result;
                }

                viewModel = new WeatherIndexViewModel()
                {
                    listaGiorni = serviceResults
                };
            } catch (Exception ex)
            {
                viewModel = new WeatherIndexViewModel()
                {
                    listaGiorni = new Giorni[0]
                };
            }

            
            return View(viewModel);
        }
    }
}