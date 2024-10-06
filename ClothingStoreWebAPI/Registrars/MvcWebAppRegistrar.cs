﻿
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace ClothingStoreWebAPI.Registrars
{
    public class MvcWebAppRegistrar : IWebApplicationRegistrar 
    {
        public void RegisterPipelineComponents(WebApplication app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.ApiVersion.ToString());
                }
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

                app.UseCors("AllowAllOrigins"); // Apply the CORS policy here


            app.MapControllers();
        }

    }
}
