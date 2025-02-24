var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();
builder.LogConfiguration();
builder.ConfigureServices();

//CUSTOM SERVICES
builder.Services.AddTransient<IFileService, FileService>();

builder.Services.AddTransient<SendGridEmailService>();

builder.Services.AddHttpClient<MailTrapEmailService>();

builder.Services.AddSingleton<IEmailFactory, EmailFactory>();

builder.Services.AddTransient<EmailService>();


if (!builder.Environment.IsProduction())
{
    builder.Configuration.AddUserSecrets<Program>();
}
builder.ConfigureDatabase<Context>();

var app = builder.Build();

app.ConfigurePipeline();
app.Run();

