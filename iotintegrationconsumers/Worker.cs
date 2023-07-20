namespace iotintegrationconsumers;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IConfiguration _configuration;
    private readonly IIotHubDataConsumer _iotHubDataConsumer;
    private readonly IDeviceDataConsumer _deviceDataConsumer;

    public Worker(ILogger<Worker> logger, IConfiguration configuration,IIotHubDataConsumer iotHubDataConsumer,IDeviceDataConsumer deviceDataConsumer)
    {
        _configuration = configuration;
        _logger = logger;
        _deviceDataConsumer=deviceDataConsumer;
        _iotHubDataConsumer= iotHubDataConsumer;
    }
    public override async Task StartAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine($"Consumer Started {DateTime.Now}");
        // Default Endpoint Consumer
        _iotHubDataConsumer.DefaultEndpointSetup();

        _deviceDataConsumer.StartConnection();
        _deviceDataConsumer.SubscribeMessage("iot-device-1");
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine($"Consumer Stopped {DateTime.Now}");
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
