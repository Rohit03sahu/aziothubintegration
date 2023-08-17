public class AppSettings
{
    private IConfiguration _Configuration;
    public DefaultEventHub DefaultEventHub;
    public string DeviceConnectionString;
    public string MongoConnectionString;

    public AppSettings(IConfiguration configuration)
    {
        _Configuration = configuration;
        
        DeviceConnectionString = _Configuration["DeviceConnectionString"];
        MongoConnectionString = _Configuration["MongoConnectionString"];

        var defaultEventHub = new DefaultEventHub();
        _Configuration.GetSection(nameof(DefaultEventHub)).Bind(defaultEventHub);
        DefaultEventHub = defaultEventHub;
    }

}

public class DefaultEventHub
{
    public string EventHubsCompatibleEndpoint { get; set; }
    public string EventHubsCompatiblePath { get; set; }
    public string IotHubSasKey { get; set; }
    public string ConsumerGroup { get; set; }
}
