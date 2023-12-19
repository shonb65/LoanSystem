using LoanSystem.Models;
using LoanSystem.Repository;
using LoanSystem.Services;
using LoanSystem.Services.LoanStrategies;
using LoanSystem.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jsonDbSettings = builder.Configuration.GetSection("JsonDbSettings").Get<JsonDbSettings>();

builder.Services.AddScoped<ILoanCalculationStrategy, Under20LoanCalculationStrategy>();
builder.Services.AddScoped<ILoanCalculationStrategy, Between20And35LoanCalculationStrategy>();
builder.Services.AddScoped<ILoanCalculationStrategy, Above35LoanCalculationStrategy>();
builder.Services.AddScoped<ILoanCalculationStrategyFactory, LoanCalculationStrategyFactory>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IRepository<User>>(provider => new JsonRepository<User>(jsonDbSettings.Path));



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
