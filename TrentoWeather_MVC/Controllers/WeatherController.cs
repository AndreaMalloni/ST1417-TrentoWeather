using Microsoft.AspNetCore.Mvc;
using TrentoWeather_MVC.ViewModels;
using static TrentoWeather_SOAP.Models.models;
using WeatherModels;

namespace TrentoWeather_MVC.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index(DateTime? day)
        {

            weather_request request = new weather_request();
            Rootobject weather = request.send();
            Giorni[] dayData = weather.previsione[0].giorni;

            if(day != null)
            {
                dayData = dayData.Where(d => d.giorno.Contains(day.Value.Date.ToString("yyyy-MM-dd"))).ToArray();
            }

            WeatherIndexViewModel viewModel = new WeatherIndexViewModel()
            {
                listaGiorni = dayData
            };

            return View(viewModel);
        }
    }
}