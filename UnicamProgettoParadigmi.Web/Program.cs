using UnicamProgettoParadigmi.Application.Extensions;
using UnicamProgettoParadigmi.Web.Extensions;
using UnicamProgettoParadigmi.Models.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();
