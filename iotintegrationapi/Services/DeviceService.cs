using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

public class DeviceService : IDeviceService
{

    //static string connectionString = "HostName=iothubdeviceintegration.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=r0uGKCJTJSbCxhug5MIa3piuJD+jOWbtTimS1CbkWHU=";
    static RegistryManager registryManager;
    private readonly AppSettings _appSettings;
    public DeviceService(AppSettings appSettings)
    {
        _appSettings = appSettings;
        registryManager = RegistryManager.CreateFromConnectionString(_appSettings.IotHUbConnectionString);
    }
    public async Task<string> AddDeviceAsync(string DeviceId)
    {
        Device device;
        try
        {
            device = await registryManager.AddDeviceAsync(new Device(DeviceId));
        }
        catch (DeviceAlreadyExistsException)
        {
            device = await registryManager.GetDeviceAsync(DeviceId);
        }
        //Console.WriteLine("Generated device key: { 0}", device.Authentication.SymmetricKey.PrimaryKey);
        return device.Authentication.SymmetricKey.PrimaryKey;
    }

    public async Task<bool> DeleteDeviceAsync(string DeviceId)
    {
        Device device;
        device = await registryManager.GetDeviceAsync(DeviceId);
        if (device != null)
        {
            await registryManager.RemoveDeviceAsync(device);
            return true;
        }
        return false;
    }

    public async Task<Device> GetDeviceAsync(string DeviceId)
    {
        Device device = await registryManager.GetDeviceAsync(DeviceId);

        return device;
    }
}

