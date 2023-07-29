using System.Text;
using Azure.Messaging.EventHubs.Consumer;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;

public interface IDeviceDataConsumer
{
    public bool StartConnection();
    public void StopConnection();
    public Task<Object> SubscribeMessage(string DeviceId);

}