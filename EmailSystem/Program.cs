
var builder = WebApplication.CreateBuilder(args);

var mailerName = builder.Configuration["MailerName"];
var logLevel = builder.Configuration["Serilog:MinimumLevel"];

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration));

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

Log.Information("MailerName is {MailerName}.\n", mailerName);
Log.Information("LogLevel is {LogLevel}.\n", logLevel);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MailDefinitionProfile));
builder.Services.AddTransient<IFileService, FileService>();



string? databaseProviderConfig = builder.Configuration["DatabaseProviderConfiguration:DatabaseProvider"];
if (string.IsNullOrWhiteSpace(databaseProviderConfig))
{
    throw new Exception("Konfiguracija za DatabaseProvider je null ili prazna.");
}

if (!Enum.TryParse<DatabaseProvider>(databaseProviderConfig.Trim(), out DatabaseProvider databaseProviderEnum))
{
    throw new Exception("Nepodrzan tip baze.");
}

var connectionString = builder.Configuration["ConnectionStrings:MailSystemCS"];
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string je null ili prazan.");
}
builder.Services.Register<Context>(connectionString, databaseProviderEnum.ToString());







var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

