using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Users.Api.Converters;
using Users.Api.Repositories;
using Users.Api.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ITimeToNextBirthdayFormatter, TimeToNextBirthdayFormatter>();
builder.Services.AddScoped<IUserService, UserService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SeedData();

void SeedData()
{
    IUserRepository userRepository = app.Services.GetService<IUserRepository>();
    var i = 1;
    DateTime now = DateTime.UtcNow;
    userRepository.Add(new Users.Api.Models.User
    {
        Id = i++,
        Name = "Andrew",
        BirthDate = new DateOnly(1990, 2, 10),
    });
    userRepository.Add(new Users.Api.Models.User
    {
        Id = i++,
        Name = "Greg",
        BirthDate = new DateOnly(1994, now.Month, now.Day),
    });
    userRepository.Add(new Users.Api.Models.User
    {
        Id = i++,
        Name = "John",
        BirthDate = new DateOnly(1994, 11, 10),
    });
    userRepository.Add(new Users.Api.Models.User
    {
        Id = i++,
        Name = "Annie",
        BirthDate = new DateOnly(1994, 12, 30),
    });
    userRepository.Add(new Users.Api.Models.User
    {
        Id = i++,
        Name = "Emma",
        BirthDate = new DateOnly(1980, 5, 20),
    });
    userRepository.Add(new Users.Api.Models.User
    {
        Id = i++,
        Name = "Olivia",
        BirthDate = new DateOnly(1994, now.Month, now.Day + 1),
    });
}

app.Run();
