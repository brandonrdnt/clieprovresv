using Ardiente.Cpr.Application.Interfaces.Persistors;
using Ardiente.Cpr.Application.Interfaces.Providers;
using Ardiente.Cpr.Infrastructure;
using Ardiente.Cpr.Infrastructure.Persistors;
using Ardiente.Cpr.Infrastructure.Providers;

namespace Ardiente.Cpr.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddSingleton<IMemoryStore, MemoryStore>();
        builder.Services.AddScoped<IMedProviderPersistor, MedProviderPersistor>();
        builder.Services.AddScoped<IMedProviderProvider, MedProviderProvider>();
        builder.Services.AddScoped<IMedClientPersistor, MedClientPersistor>();
        builder.Services.AddScoped<IMedClientProvider, MedClientProvider>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}