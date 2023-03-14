using EmployeeApi;
using EmployeeApi.Interface;
using EmployeeApi.Model;
using EmployeeApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context1>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Test1"));    
});
builder.Services.AddDbContext<Context2>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Test2"));
});
builder.Services.AddDbContext<Context3>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Test3"));
});

builder.Services.AddControllers();
builder.Services.AddTransient<IEmployee, EmployeeService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
