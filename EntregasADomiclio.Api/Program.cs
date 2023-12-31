using EntregasADomicilio.BusinessLayer.Helpers;
using Serilog;
using Vmartinez.RequestInspector.Extensores;
using VMtz.RequestInspector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AgregarBl();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.ReadFrom.Configuration(hostContext.Configuration);
});

builder.Services.AddRequestInpector();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}
app.UseMiddleware<RequestInspectorMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
