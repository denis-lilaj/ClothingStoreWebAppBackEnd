
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWebAPI.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            var cs = builder.Configuration.GetConnectionString("Conn");
            builder.Services.AddDbContext<DbContextCustom>(options=>options.UseNpgsql(cs));
        }
    }
}
