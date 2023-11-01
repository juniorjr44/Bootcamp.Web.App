using AutoMapper;
using Bootcamp.Api.Bls;
using Bootcamp.Api.Data;
using Microsoft.Extensions.Configuration;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration
 .SetBasePath(Directory.GetCurrentDirectory())
 .AddJsonFile($"appsettings.json", optional: false)
 .AddJsonFile($"appsettings.{env}.json", optional: true)
 .AddEnvironmentVariables()
 .Build();

// Add services to the container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IContactBL, ContactBL>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile<MapperProfile>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddCors(options =>
{
    options.AddPolicy(configuration["CorsSettings:Policy"],
    builder =>
    {
        builder.WithOrigins(configuration["CorsSettings:WhiteListLinks"])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
    });
});


var app = builder.Build();
app.UseCors(configuration["CorsSettings:Policy"]);


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
