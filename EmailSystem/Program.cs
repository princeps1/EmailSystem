using PrincepsLibrary.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureLogging();
builder.LogConfiguration();
builder.ConfigureServices();
builder.ConfigureCustomServices();
builder.ConfigureDatabase<Context>();

var app = builder.Build();

app.ConfigurePipeline();
app.Run();

