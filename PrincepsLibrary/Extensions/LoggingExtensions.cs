namespace PrincepsLibrary.Extensions;

public static class LoggingExtensions
{
    public static void ConfigureLogging(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((context, services, configuration) => configuration
            .ReadFrom.Configuration(context.Configuration));
    }

    public static void LogConfiguration(this WebApplicationBuilder builder)
    {
        var mailerName = builder.Configuration["MailerName"];
        var logLevel = builder.Configuration["Serilog:MinimumLevel"];

        Log.Information("MailerName is {MailerName}.\n", mailerName);
        Log.Information("LogLevel is {LogLevel}.\n", logLevel);
    }
}
