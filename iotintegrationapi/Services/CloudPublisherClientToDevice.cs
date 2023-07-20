using System.Text;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

public class CloudPublisherClientToDevice:ICloudPublisherClientToDevice
{
    static ServiceClient serviceClient;
    string _DeviceId;
    //static string connectionString = "HostName=iothubdeviceintegration.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=r0uGKCJTJSbCxhug5MIa3piuJD+jOWbtTimS1CbkWHU=";
    private readonly AppSettings _appSettings;
    public CloudPublisherClientToDevice(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }
    public bool StartConnection()
    {
        serviceClient = ServiceClient.CreateFromConnectionString(_appSettings.IotHUbConnectionString);
        return true;
    }

    public async void StopConnection()
    {
        await serviceClient.CloseAsync();
    }

    public async Task SendCloudToDeviceMessageAsync(string DeviceId,string Payload)
    {
        var commandMessage = new Microsoft.Azure.Devices.Message(Encoding.ASCII.GetBytes(Payload));
        await serviceClient.SendAsync(DeviceId, commandMessage);
    }

    public async Task<Object> SubscribeMessage(string DeviceId)
    {
        var feedbackReceiver = serviceClient.GetFeedbackReceiver();

        Console.WriteLine("\nReceiving c2d feedback from service");
        while (true)
        {
            var feedbackBatch = await feedbackReceiver.ReceiveAsync();
            if (feedbackBatch == null) continue;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Received feedback: {0}",
              string.Join(", ", feedbackBatch.Records.Select(f => f.StatusCode)));
            Console.ResetColor();

            await feedbackReceiver.CompleteAsync(feedbackBatch);
        }
    }
}