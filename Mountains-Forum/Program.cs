using Mountains_Forum.Entities;
using Mountains_Forum.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IMainService, MainService>();

builder.Services.AddDbContext<ForumDbContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
