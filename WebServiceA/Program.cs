using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using WebServiceA.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddOpenTelemetry().ConfigureResource(resourceBuilder => resourceBuilder.AddService("WebServiceA"))
    .WithTracing(providerBuilder =>
    {
        providerBuilder
            .AddSource("WebServiceA")
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddOtlpExporter(options => { options.Endpoint = new Uri("http://localhost:4317"); });
    })
    .WithLogging(providerBuilder =>
    {
        providerBuilder.AddOtlpExporter(options => { options.Endpoint = new Uri("http://localhost:4317"); })
            .AddConsoleExporter();
    })
    .WithMetrics(providerBuilder =>
    {
        providerBuilder.AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddOtlpExporter(options => { options.Endpoint = new Uri("http://localhost:4317"); });
    });
builder.Logging.AddOpenTelemetry(options =>
{
    options.IncludeScopes = true;
    options.IncludeFormattedMessage = true;
});

builder.Services.AddSingleton(TracerProvider.Default.GetTracer("WebServiceA", "1.0.0"));

builder.Services.AddHttpClient<IProductService, ProductService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5215"); // Assuming WebServiceB is running on this address
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();