using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using WebServiceB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddOpenTelemetry().ConfigureResource(resourceBuilder => resourceBuilder.AddService("WebServiceB"))
    .WithTracing(providerBuilder =>
    {
        providerBuilder
            .AddSource("WebServiceB")
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddOtlpExporter(options => { options.Endpoint = new Uri("http://localhost:4317"); });
    })
    .WithLogging(providerBuilder =>
    {
        providerBuilder.AddOtlpExporter(options => { options.Endpoint = new Uri("http://localhost:4317"); })
            .AddConsoleExporter();
    });

builder.Services.AddSingleton(TracerProvider.Default.GetTracer("WebServiceB", "1.0.0"));
builder.Services.AddScoped<IDiscountService, DiscountService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

