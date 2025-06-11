using dotenv.net;
using Microsoft.EntityFrameworkCore;
using SmartStock.Application.Interfaces;
using SmartStock.Application.UseCases;
using SmartStock.Infrastructure.Data;
using SmartStock.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DotEnv.Load();

var dbUrl = Environment.GetEnvironmentVariable("DB_URL");
// Console.WriteLine($"Database URL: {dbUrl}");

if (string.IsNullOrEmpty(dbUrl))
{
    throw new InvalidOperationException("DB_URL environment variable is not set.");
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRegisterStockItemUseCase, RegisterStockItemUseCase>();
builder.Services.AddScoped<IGetStockItemByIdUseCase, GetStockItemByIdUseCase>();
builder.Services.AddScoped<IGetAllStockItemsUseCase, GetAllStockItemsUseCase>();
builder.Services.AddScoped<IUpdateStockItemUseCase, UpdateStockItemUseCase>();
builder.Services.AddScoped<IDeleteStockItemByIdUseCase, DeleteStockItemByIdUseCase>();
builder.Services.AddScoped<IStockItemRepository, StockItemRepository>();

builder.Services.AddScoped<IRegisterStockEntryUseCase, RegisterStockEntryUseCase>();
builder.Services.AddScoped<IStockEntryRepository, StockEntryRepository>();
builder.Services.AddScoped<IGetStockEntryByIdUseCase, GetStockEntryByIdUseCase>();
builder.Services.AddScoped<IGetAllStockEntryUseCase, GetAllStockEntryUseCase>();
builder.Services.AddScoped<IUpdateStockEntryUseCase, UpdateStockEntryUseCase>();
builder.Services.AddScoped<IDeleteStockEntryUseCase, DeleteStockEntryUseCase>();

builder.Services.AddDbContext<SmartStockDbContext>(options =>
    options.UseNpgsql(dbUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();