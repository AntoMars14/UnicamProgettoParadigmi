using FluentValidation;
using UnicamProgettoParadigmi.Application.Abstractions;
using UnicamProgettoParadigmi.Application.Services;

namespace UnicamProgettoParadigmi.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
    AppDomain.CurrentDomain.GetAssemblies().
           SingleOrDefault(assembly => assembly.GetName().Name == "UnicamProgettoParadigmi.Application")
    );

            services.AddScoped<IListaDistribuzioneService, ListaDistribuzioneService>();
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }
    }
}
