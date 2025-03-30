using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using SinglePaymentAPI.Data;
using SinglePaymentAPI.Data.Repository.Transfers;
using SinglePaymentAPI.Data.Repository.Wallets;

var builder = WebApplication.CreateBuilder(args);

// .env and configuration
Env.Load();
var dbConnection = Env.GetString("DB_CONNECTION");
builder.Configuration["ConnectionStrings:defaultConnection"] = dbConnection;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serverVersion = new MySqlServerVersion(new Version(8, 0, 41));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("defaultConnection"), serverVersion));

builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<ITransferRepository, TransferRepository>();

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

Console.WriteLine($"Minha Connection String: {builder.Configuration["ConnectionStrings:defaultConnection"]}");

app.Run();
