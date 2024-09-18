using Application.UserProfiles.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ClothingStoreWebAPI.Registrars
{
    public class BogardRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Program), typeof(GetAllUserProfilesQuery));

            builder.Services.AddMediatR(typeof(GetAllUserProfilesQuery));
        }
    }
}
