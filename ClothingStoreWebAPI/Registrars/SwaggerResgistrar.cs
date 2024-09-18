
using ClothingStoreWebAPI.Controllers.Options;

namespace ClothingStoreWebAPI.Registrars
{
    public class SwaggerResgistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}
