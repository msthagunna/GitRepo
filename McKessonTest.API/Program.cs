using McKessonTest.API.Configurations;
using McKessonTest.API.Middlewares;
using McKessonTest.API.Services;
using McKessonTest.API.Services.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Adding log4net service
builder.Logging.ClearProviders();//clear all inbuilt logging provider
builder.Logging.AddLog4Net();

//Adding Automapper Service
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

//Adding Repository service
builder.Services.AddScoped(typeof(ILocationService), typeof(LocationService));

//Adding Exception Handler middleware
builder.Services.AddExceptionHandler<APIExceptionHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    // Hide Model schemas showing on swagger UI
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(_ => { });

app.Run();
