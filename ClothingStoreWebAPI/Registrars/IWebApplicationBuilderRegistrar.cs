using ClothingStoreWebAPI.Registrars;
namespace ClothingStoreWebAPI.Registrars
{
    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}
