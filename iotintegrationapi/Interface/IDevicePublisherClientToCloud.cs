using System.Text;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

public interface IDevicePublisherClientToCloud
{
    public bool StartConnection(string DeviceId, string DeviceKey);
    public void StopConnection();
    public Task<bool> SendDeviceToCloud(Object telemetryDataPoint);
}