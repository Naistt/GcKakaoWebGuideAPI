using GcKakaoWebGuideAPI.Application.Services;
using GcKakaoWebGuideAPI.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.AspNetCore.Builder;
using GcKakaoWebGuideAPI.Extensions;


var builder = FunctionsApplication.CreateBuilder(args);
//builder.Services.Configure<MongoSettings>(options =>
//{
//    options.ConnectionString = "mongodb+srv://alvesvini1337:fKxMHzGa0erd8EXw@gckakaowebguide-cluster.pzlse.mongodb.net/?retryWrites=true&w=majority&appName=GCKakaoWebGuide-Cluster0";
//    options.DatabaseName = "GcKakaoWebGuideAPI";
//});

builder.Services.AddSingleton<MongoDbConfig>();
//builder.Services.AddScoped<UsuarioService>();
//builder.Services.AddScoped<HeroiService>();

//builder.ConfigureFunctionsWebApplication();

// 🔹 Adiciona CORS ao container de serviços
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddCors(options => {
        options.AddPolicy("AllowAngularApp",
            policy =>
            {
                policy.WithOrigins("http://localhost:4200") // Permite chamadas do Angular
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
    });

builder.Services.AddControllers();
var app = builder.Build();

app.Run();

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
// builder.Services
//     .AddApplicationInsightsTelemetryWorkerService()
//     .ConfigureFunctionsApplicationInsights();

//builder.Build().Run();
