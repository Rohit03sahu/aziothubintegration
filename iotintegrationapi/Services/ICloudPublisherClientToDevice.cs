using System.Text;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

public interface ICloudPublisherClientToDevice
{
    public bool StartConnection();
    public void StopConnection();    
    public Task SendCloudToDeviceMessageAsync(string DeviceId,string Payload);
    public Task<Object> SubscribeMessage(string DeviceId);
}