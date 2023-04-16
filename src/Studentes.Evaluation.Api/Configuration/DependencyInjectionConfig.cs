using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Studentes.Evaluation.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddHttpClient<IAuthService, AuthService>();
            
        }
    }
}
