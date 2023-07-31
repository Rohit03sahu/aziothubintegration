using DeviceProvisioning;
using Microsoft.AspNetCore.Mvc;

namespace iotintegrationapi.Controllers;

[ApiController]
[Route("api/provision")]
public class DeviceProvisionController : ControllerBase
{
    private readonly ILogger<DeviceProvisionController> _logger;
    private readonly IDevicePublisherClientToCloud _devicePublisherClientToCloud;
    private readonly IDeviceProvisionService _deviceService;
    private readonly AppSettings _appSettings;

    public DeviceProvisionController(IDevicePublisherClientToCloud devicePublisherClientToCloud, IDeviceProvisionService deviceService, AppSettings appSettings, ILogger<DeviceProvisionController> logger)
    {
        _logger = logger;
        _devicePublisherClientToCloud = devicePublisherClientToCloud;
        _deviceService = deviceService;
        _appSettings = appSettings;
    }

    // [HttpGet (Name="RegisterDevice")]
    // public ActionResult<bool> RegisterDevice()
    // {
    //     string scopeId = "iot-device-2";
    //     CertificateFactory.CreateTestCert();
    //     var device = new DeviceProvisioningService(scopeId);
    //     var provisionStatus = device.Provision().Result;
    //     var connectAndRunStatus = device.ConnectAndRun().Result;
    //     return connectAndRunStatus;
    // }


    [HttpGet]
    [Route("GetDevice")]
    public IActionResult GetDevice(string DeviceId)
    {
        return Ok(_deviceService.GetDeviceAsync(DeviceId).Result);
    }

    [HttpPost]
    [Route("RegisterDevice")]
    public IActionResult RegisterDevice(string DeviceId)
    {
        return Ok(_deviceService.AddDeviceAsync(DeviceId).Result);
    }

    [HttpDelete]
    [Route("DeleteDevice")]
    public IActionResult DeleteDevice(string DeviceId)
    {
        return Ok(_deviceService.DeleteDeviceAsync(DeviceId).Result);
    }
}