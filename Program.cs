using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NewsAnalysisAPI.Services;

var builder = WebApplication.CreateBuilder(args);


//// CORS Politikasý 
//IServiceCollection serviceCollection = builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontend",
//        policy =>
//        {
//            policy.WithOrigins(alowedOrigins) // Frontend URL'si (React, Angular, vs.)
//                  .AllowAnyHeader()
//                  .AllowAnyMethod();
//        });

//});

var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(allowedOrigins) // JSON'dan gelen URL'leri kullan
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Servisler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servisleri Dependency Injection ile ekleyelim
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IAnalysisService, AnalysisService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// API'yi çalýþtýrmak için middleware

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.MapControllers();
app.Run();
