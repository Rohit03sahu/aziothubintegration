using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

public interface IDeviceProvisionService
{
    public Task<string> AddDeviceAsync(string DeviceId);
    public Task<bool> DeleteDeviceAsync(string DeviceId);
    public Task<Device> GetDeviceAsync(string DeviceId);
}

