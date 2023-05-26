using Cukcuk.Backend.BL.BaseBL;
using Cukcuk.Backend.BL.CategoryBL;
using Cukcuk.Backend.BL.MaterialBL;
using Cukcuk.Backend.BL.StoreBL;
using Cukcuk.Backend.BL.UnitBL;
using Cukcuk.Backend.DL.BaseDL;
using Cukcuk.Backend.DL.CategoryDL;
using Cukcuk.Backend.DL.Database;
using Cukcuk.Backend.DL.MaterialDL;
using Cukcuk.Backend.DL.StoreDL;
using Cukcuk.Backend.DL.UnitDL;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
builder.Services.AddScoped<IUnitBL, UnitBL>();
builder.Services.AddScoped<IUnitDL, UnitDL>();

builder.Services.AddScoped<IStoreBL, StoreBL>();
builder.Services.AddScoped<IStoreDL, StoreDL>();

builder.Services.AddScoped<ICategoryBL, CategoryBL>();
builder.Services.AddScoped<ICategoryDL, CategoryDL>();

builder.Services.AddScoped<IMaterialBL, MaterialBL>();
builder.Services.AddScoped<IMaterialDL, MaterialDL>();

// Database connection
DatabaseContext.connectionString = builder.Configuration.GetConnectionString("Default");

// Disable auto validations
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:8080")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowOrigin");

app.MapControllers();

app.Run();
