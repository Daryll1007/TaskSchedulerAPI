using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskSchedulerAPI.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TaskSchedulerContext>(options =>
    options.UseInMemoryDatabase("TaskSchedulerDb")); 

builder.Services.AddControllers();

var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
