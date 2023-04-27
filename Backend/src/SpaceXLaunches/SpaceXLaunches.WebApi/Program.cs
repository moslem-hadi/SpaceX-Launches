using SpaceXLaunches.Infrastructure.Configs;
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.Configure<UrlsConfig>(
    builder.Configuration.GetSection("Urls"));
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
var MyAllowSpecificOrigins = "_localhost";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000",
                                              "https://localhost:3000");
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
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();


app.MapControllers();

app.Run();