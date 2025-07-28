
using Famiry.Data;
using Famiry.Service;
using FamiryEntityLibrary;
using FamiryEntityLibrary.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddEnvironmentVariables();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
RegisterCoreServices(builder.Services);
RegisterDataSources(builder.Services);

var application = builder.Build();

application.UseSwagger();
application.UseSwaggerUI();
application.MapControllers();
application.MapHealthChecks("/health");
application.UseCors();

await InitializeDataSources(application);


application.Run();

void RegisterCoreServices(IServiceCollection services)
{
    services.AddScoped<PhotoService>();
    services.AddScoped<CommentService>();
    services.AddScoped<EventService>();
    services.AddScoped<UserService>();
    services.AddControllers();
}

void RegisterDataSources(IServiceCollection services)
{
    var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
    var dbName = Environment.GetEnvironmentVariable("POSTGRES_DB");
    var dbUser = Environment.GetEnvironmentVariable("POSTGRES_USER");
    var dbPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
    var connectionString = $"Server={dbHost};Port=5432;Database={dbName};User Id={dbUser};Password={dbPassword};";
    services.AddScoped(provider => new DataContext(new ContextConfiguration(connectionString, "famiry")));
}

async Task InitializeDataSources(WebApplication application)
{
    using var scope = application.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    await dataContext.TryInitializeAsync();


    await scope.ServiceProvider.GetRequiredService<TypeService>().Set(dataContext.Types, new List<FamiryEntityLibrary.Type> {
                new FamiryEntityLibrary.Type {Id=1,Name="Без типа"},
                new FamiryEntityLibrary.Type {Id=2,Name="Task"},
                new FamiryEntityLibrary.Type {Id=3,Name="Event"},
                new FamiryEntityLibrary.Type {Id=1,Name="Target"},
            });
    await scope.ServiceProvider.GetRequiredService<PriorityService>().Set(dataContext.Priorities, new List<Priority> {
                new Priority {Id=1,Name="Без типа"},
                new Priority {Id=2,Name="Not Important"},
                new Priority {Id=3,Name="Important"},
                new Priority {Id=4,Name="Very Important"},
                new Priority {Id=5,Name="Slightly Important"},
                new Priority {Id=6,Name="Emergency" }
            });

    await scope.ServiceProvider.GetRequiredService<StatusService>().Set(dataContext.Statuses, new List<Status> {
                new Status {Id=1,Name="Без типа"},
                new Status {Id=2,Name="completed"},
                new Status {Id=3,Name="Not complited"}
            });
}
