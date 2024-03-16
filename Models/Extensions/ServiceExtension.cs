using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamProgettoParadigmi.Models.Context;
using UnicamProgettoParadigmi.Models.Repositories;

namespace UnicamProgettoParadigmi.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<UtenteRepository>();
            services.AddScoped<ListaDistribuzioneRepository>();
            services.AddScoped<EmailRepository>();
            services.AddScoped<ListaDistribuzioneEmailRepository>();
            return services;
        }
    }
}
