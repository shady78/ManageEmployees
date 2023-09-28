using ManageEmployees.API.Data;
using ManageEmployees.API.Data.Base;
using ManageEmployees.API.Data.Interface;
using ManageEmployees.API.Data.Repositories;
using ManageEmployees.API.Dtos.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddScoped<IEmployeeRepository , EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();
builder.Services.AddScoped<IContractRepository , ContractRepository>();

//use AutoMapper
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

//ManageEmployeesDbInitializer.Initialize(app.ApplicationServices);


builder.Services.AddControllers();
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
