
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreWebAPI.Registrars
{
    public class MvcRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddApiVersioning(config => {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            builder.Services.AddVersionedApiExplorer(config => {
                config.GroupNameFormat = "'v','VVV'";
                config.SubstituteApiVersionInUrl = true;
            }
            
            );
           builder.Services.AddCors(options =>
                {
                   options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()                // Allow all origins
                           .AllowAnyMethod()                // Allow all HTTP methods (GET, POST, etc.)
                           .AllowAnyHeader();               // Allow any headers
        });
    });
            
        }
    }
}
