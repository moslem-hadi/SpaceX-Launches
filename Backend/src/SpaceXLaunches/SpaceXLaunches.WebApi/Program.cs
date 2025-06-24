using SpaceXLaunches.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApiServices(builder.Configuration);
builder.AddLogging();

builder.Services.AddCors();

var app = builder.Build();

app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();
app.MapControllers();

app.Run();
