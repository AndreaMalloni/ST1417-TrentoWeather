using Newtonsoft.Json;
using static TrentoWeather_SOAP.Models.models;

namespace WeatherModels
{
    public class weather_request
    {
        public Rootobject send()
        {
            string Uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(Uri).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        String result = content.ReadAsStringAsync().Result;
                        Rootobject data = JsonConvert.DeserializeObject<Rootobject>(result);
                        return data;
                    }
                }
            }
        }
    }
}
