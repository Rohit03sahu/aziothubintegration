public class AppSettings
{
    private IConfiguration _Configuration;
    public DefaultEventHub DefaultEventHub;
    public CustomEventHub CustomEventHub;
    public string DeviceConnectionString;
    public string MongoConnectionString;
    public bool IsDefaultEventHubEnable;

    public AppSettings(IConfiguration configuration)
    {
        _Configuration = configuration;
        
        DeviceConnectionString = _Configuration["DeviceConnectionString"];
        MongoConnectionString = _Configuration["MongoConnectionString"];
        IsDefaultEventHubEnable = Convert.ToBoolean(_Configuration["IsDefaultEventHubEnable"]);

        var defaultEventHub = new DefaultEventHub();
        _Configuration.GetSection(nameof(DefaultEventHub)).Bind(defaultEventHub);
        DefaultEventHub = defaultEventHub;

        var customEventHub = new CustomEventHub();
        _Configuration.GetSection(nameof(CustomEventHub)).Bind(customEventHub);
        CustomEventHub = customEventHub;
    }

}

public class DefaultEventHub
{
    public string EventHubsCompatibleEndpoint { get; set; }
    public string EventHubsCompatiblePath { get; set; }
    public string IotHubSasKey { get; set; }
    public string ConsumerGroup { get; set; }
}

public class CustomEventHub
{
    public string EventHubsCompatibleEndpoint { get; set; }
    public string EventHubsCompatiblePath { get; set; }
    public string IotHubSasKey { get; set; }
    public string ConsumerGroup { get; set; }
}
