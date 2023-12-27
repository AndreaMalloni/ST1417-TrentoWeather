using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using TrentoWeather_MVC.ViewModels;

namespace TrentoWeather_MVC.Controllers
{
    public class WeatherController : Controller
    {

        public IActionResult Index()
        {
            ISoapService soapServiceChannel = new SoapServiceClient(SoapServiceClient.EndpointConfiguration.BasicHttpBinding_ISoapService_soap);
            var sunResponse = soapServiceChannel.GetWeatherAsync(null).Result;

            
            return View();
        }
    }
}
