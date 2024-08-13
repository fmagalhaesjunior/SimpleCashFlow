using Application.Configuration.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

Configure(app, builder.Environment);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    
    //Adicionar Injeção de dependência
    services.AddInfrastructureDI();
    services.AddApplicationDI();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

void Configure(WebApplication app, IHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();
    app.UseAuthorization();
    app.MapControllers();
}
