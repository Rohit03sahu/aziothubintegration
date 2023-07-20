using System.Text;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

public class DevicePublisherClientToCloud:IDevicePublisherClientToCloud
{
    private DeviceClient deviceClient;
    string _DeviceId;
    string _DeviceKey;
    private readonly AppSettings _appSettings;
    public DevicePublisherClientToCloud(AppSettings AppSettings)
    {
        _appSettings = AppSettings;
    }

    public bool StartConnection(string DeviceId, string DeviceKey)
    {
        var deviceAuthentication = new DeviceAuthenticationWithRegistrySymmetricKey(DeviceId, DeviceKey);
        deviceClient = DeviceClient.Create(_appSettings.IotHubHostName, deviceAuthentication, TransportType.Mqtt);
        return true;
    }

    public async void StopConnection()
    {
        await deviceClient.CloseAsync();
    }

    public async Task<bool> SendDeviceToCloud(Object telemetryDataPoint)
    {
        string messageString = JsonConvert.SerializeObject(telemetryDataPoint);
        Message message = new Message(Encoding.ASCII.GetBytes(messageString));
        //message.Properties.Add("SampleProp", ((double)20 > 30) ? "true" : "false");
        await deviceClient.SendEventAsync(message);
        return true;
    }
}