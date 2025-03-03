var builder = WebApplication.CreateBuilder(args);

//CONFIGURE LOGGING
builder.Host.UseSerilog((context, services, configuration) => configuration
           .ReadFrom.Configuration(context.Configuration));
var mailerName = builder.Configuration["MailerName"];
var logLevel = builder.Configuration["Serilog:MinimumLevel"];

Log.Information("MailerName is {MailerName}.\n", mailerName);
Log.Information("LogLevel is {LogLevel}.\n", logLevel);


//SERVICES
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
builder.Services.AddControllers();
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
builder.Services.AddAutoMapper(typeof(MailDefinitionProfile));


//CONFIGURE CUSTOM SERVICES
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<SendGridEmailService>();
builder.Services.AddHttpClient<MailTrapEmailService>();
builder.Services.AddSingleton<IEmailFactory, EmailFactory>();
builder.Services.AddTransient<EmailService>();


if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}
//CONFIGURE DATABASE
builder.ConfigureDatabase<Context>();


var app = builder.Build();

//PIPELINE  
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

