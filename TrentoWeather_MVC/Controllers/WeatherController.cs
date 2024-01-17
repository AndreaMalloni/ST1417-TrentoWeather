using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using TrentoWeather_MVC.ViewModels;

namespace TrentoWeather_MVC.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index(String day)
        {
            ISoapService soapServiceChannel = new SoapServiceClient(SoapServiceClient.EndpointConfiguration.BasicHttpBinding_ISoapService_soap);

            var response = soapServiceChannel.GetWeatherAsync(new GetWeatherRequest()
            {
                Body = new GetWeatherRequestBody()
                {
                    day = day
                }
            }).Result;


            WeatherIndexViewModel viewModel = new WeatherIndexViewModel()
            {
                listaGiorni = response.Body.GetWeatherResult.ToArray()
            };

            return View(viewModel);
        }
    }
}