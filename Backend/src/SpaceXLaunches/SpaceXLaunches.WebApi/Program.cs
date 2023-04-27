using SpaceXLaunches.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApiServices(builder.Configuration);
builder.AddLogging();

var MyAllowSpecificOrigins = "_localhost";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
                      });
});

var app = builder.Build();

app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
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