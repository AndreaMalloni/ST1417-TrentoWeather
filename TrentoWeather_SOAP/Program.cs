using SoapCore;
using static TrentoWeather_SOAP.Logic.ServiceLogic;

namespace TrentoWeather_SOAP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSoapCore();
            builder.Services.AddScoped<ISoapService, SoapService>();

            var app = builder.Build();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.UseSoapEndpoint<ISoapService>("/Service.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
            });

            app.Run("http://0.0.0.0:8080");
        }
    }
}