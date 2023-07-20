public class AppSettings
{
    private IConfiguration _Configuration;
    public string IotHubHostName;
    public string IotHUbConnectionString;
    public AppSettings(IConfiguration configuration)
    {
        _Configuration = configuration;
        IotHubHostName = _Configuration["IotHubHostName"];
        IotHUbConnectionString = _Configuration["IotHUbConnectionString"];
    }

}