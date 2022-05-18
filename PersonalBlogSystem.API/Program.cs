using PersonalBlogSystem.Bll.Containers.MicrosoftIOC;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencies(builder.Configuration);
builder.Services.AddControllers().AddValidationDependencies();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddConfiguredSwaggerGen(assembly: Assembly.GetExecutingAssembly());


builder.Logging.AddConfiguredSerilog();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();