using iotintegrationconsumers;

var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var Configuration = builder.Build();



IHost host = Host.CreateDefaultBuilder(args)
.ConfigureServices(services =>
{
    services.AddSingleton<AppSettings>();
    services.AddTransient<IIotHubDataConsumer, IotHubDataConsumer>();
    services.AddTransient<IDeviceDataConsumer, DeviceDataConsumer>();
    services.AddHostedService<Worker>();
})
.Build();


host.Run();
