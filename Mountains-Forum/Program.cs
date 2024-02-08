using Mountains_Forum.Entities;
using Mountains_Forum.Middleware;
using Mountains_Forum.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IMainService, MainService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddDbContext<ForumDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mountains Forum API");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
