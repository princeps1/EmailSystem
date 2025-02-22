using EmailSystem.Contracts;
using EmailSystem.Domain.Entities;
using EmailSystem.Services;

namespace PrincepsLibrary.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
        });
        builder.Services.AddControllers();
        builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
        builder.Services.AddAutoMapper(typeof(MailDefinitionProfile));

    }

    public static void ConfigureCustomServices(this WebApplicationBuilder builder)
    {

        //CUSTOM SERVICES
        builder.Services.AddTransient<IFileService, FileService>();
    }
}
