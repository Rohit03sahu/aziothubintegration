using System.Text;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;

public class DeviceDataConsumer : IDeviceDataConsumer
{
    private DeviceClient _deviceClient;
    private readonly AppSettings _appSettings;
    //static string deviceConnectionString = _appSettings.DeviceConnectionString;// "HostName=iothubdeviceintegration.azure-devices.net;DeviceId=iot-device-1;SharedAccessKey=Tda+qadBy0rG55SeSYwq84fOidTzRLzJUqhQOm+gZbY=";

    public DeviceDataConsumer(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public bool StartConnection()
    {
        _deviceClient = DeviceClient.CreateFromConnectionString(_appSettings.DeviceConnectionString, Microsoft.Azure.Devices.Client.TransportType.Mqtt);
        return true;
    }

    public async void StopConnection()
    {
        await _deviceClient.CloseAsync();
    }

    public async Task<Object> SubscribeMessage(string DeviceId)
    {
        while (true)
        {
            var receivedMessage = await _deviceClient.ReceiveAsync(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            if (receivedMessage != null)
            {
                var messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                Console.WriteLine($"Device {DeviceId} Received Message : {messageData}");
                //TODO: handle incoming message and publish to common 
                await _deviceClient.CompleteAsync(receivedMessage).ConfigureAwait(false);
            }
        }

    }


}