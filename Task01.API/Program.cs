using FluentValidation;
using System.Reflection;
using Task01.API.AutoMapperProfiles;
using Task01.API.Extensions;
using Task01.API.Middlewares;
using Task01.Application.Services;
using Task01.Domain.Contracts.Services;
using Task01.Domain.Interfaces;
using Task01.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.ConfigureCors();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.Load("Task01.Application")));
builder.Services.AddValidatorsFromAssembly(Assembly.Load("Task01.Application"));

#region Services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
app.Run();
