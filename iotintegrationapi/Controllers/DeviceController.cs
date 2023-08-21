using Microsoft.AspNetCore.Mvc;

namespace iotintegrationapi.Controllers;

[ApiController]
[Route("api")]
public class DeviceController : ControllerBase
{
    private readonly ILogger<DeviceController> _logger;
    private readonly IDevicePublisherClientToCloud _devicePublisherClientToCloud;
    private readonly ICloudPublisherClientToDevice _cloudPublisherClientToDevice;
    private readonly ICustomEventHubService _customEventHubService;
    private readonly AppSettings _appSettings;

    public DeviceController(IDevicePublisherClientToCloud devicePublisherClientToCloud,ICloudPublisherClientToDevice cloudPublisherClientToDevice, AppSettings appSettings, ILogger<DeviceController> logger,
        ICustomEventHubService customEventHubService)
    {
        _logger = logger;
        _devicePublisherClientToCloud = devicePublisherClientToCloud;
        _cloudPublisherClientToDevice = cloudPublisherClientToDevice;
        _appSettings = appSettings;
        _customEventHubService = customEventHubService;
    }

    [HttpPost]
    [Route("SendDeviceToIotHub")]
    public async Task<IActionResult> SendDeviceToIotHub(string DeviceId, string DeviceKey, string Payload)
    {
        _devicePublisherClientToCloud.StartConnection(DeviceId, DeviceKey);
        var telemetryDataPoint = new
        {
            messageId = Guid.NewGuid().ToString(),
            deviceId = DeviceId,
            Payload=Payload
        };
        var resp = await _devicePublisherClientToCloud.SendDeviceToCloud(telemetryDataPoint);
        _devicePublisherClientToCloud.StopConnection();
        return Ok(resp);
    }


    [HttpPost]
    [Route("SendDataIotHubToDevice")]
    public async Task<IActionResult> SendDataToDevice(string DeviceId, string Payload)
    {
        _cloudPublisherClientToDevice.StartConnection();
        //var resp = await cloudPublisherClientToDevice.SubscribeMessage(DeviceId);
        await _cloudPublisherClientToDevice.SendCloudToDeviceMessageAsync(DeviceId, Payload);
        _cloudPublisherClientToDevice.StopConnection();
        return Ok(true);
    }


    [HttpPost]
    [Route("SendDataToCustomEventHub")]
    public async Task<IActionResult> SendDataToCustomEventHub(string Payload)
    {
        var resp = await _customEventHubService.PublishToCustomEndpoint(Payload);        
        return Ok(resp);
    }



}
