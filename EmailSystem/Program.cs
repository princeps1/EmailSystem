var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var databaseProvider = builder.Configuration["DatabaseProvider"];
var connectionString = builder.Configuration.GetConnectionString(databaseProvider);
builder.Services.AddDbContext<Context>(options =>
{
    switch (databaseProvider)
    {
        case "SqlServer":
            options.UseSqlServer(connectionString, sqlOptions =>
                sqlOptions.MigrationsAssembly("EmailSystem.Migrations.SqlServer"));
            break;
        case "PostgreSQL":
            options.UseNpgsql(connectionString, npgsqlOptions =>
                npgsqlOptions.MigrationsAssembly("EmailSystem.Migrations.PostgreSQL"));
            break;
        case "MySQL":
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
                mySqlOptions.MigrationsAssembly("EmailSystem.Migrations.MySQL"));
            break;
        default:
            throw new Exception("Nepodržan tip baze: " + databaseProvider);
    }
});

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

