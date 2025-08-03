
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NewsAnalysisAPI.Services;
using System;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IAnalysisService, AnalysisService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS yönlendirme
//app.UseHttpsRedirection();

// CORS policy uygulamasý (isim eþleþmeli!)
app.UseCors("AllowFrontend");

// Authorization middleware (þimdilik boþ ama hazýr olsun)
app.UseAuthorization();

// Controller route’larý
app.MapControllers();

app.Run();
