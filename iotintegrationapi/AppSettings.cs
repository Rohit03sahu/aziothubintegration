public class AppSettings
{
    private IConfiguration _Configuration;
    public string IotHubHostName;
    public string IotHUbConnectionString;
    public string MongoConnectionString;
    public string CustomEventHubConnectionString;
    public AppSettings(IConfiguration configuration)
    {
        _Configuration = configuration;
        IotHubHostName = _Configuration["IotHubHostName"];
        IotHUbConnectionString = _Configuration["IotHUbConnectionString"];
        MongoConnectionString = _Configuration["MongoConnectionString"];
        CustomEventHubConnectionString = _Configuration["CustomEventHubConnectionString"];
    }

}