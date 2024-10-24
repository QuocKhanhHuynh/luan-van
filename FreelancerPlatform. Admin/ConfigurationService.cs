using FluentValidation.AspNetCore;
using FreelancerPlatform.Application.Dtos.Account;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FreelancerPlatform._Admin
{
    public static class ConfigurationService
    {
        public static IServiceCollection AddPresentService(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSession(x => x.IdleTimeout = TimeSpan.FromMinutes(60));
            services.AddHttpClient();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LoginPath = "/dang-nhap";
            });

            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PasswordUpdateRequestValidator>());

            return services;
        }
    }
}