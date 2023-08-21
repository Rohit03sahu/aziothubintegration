using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
namespace iotintegrationapi.Controllers;

[ApiController]
[EnableCors("_myAllowSpecificOrigins")]
[Route("api")]
public class DeviceLocationController : ControllerBase
{
    private readonly ILogger<DeviceController> _logger;
    private readonly AppSettings _appSettings;
    private readonly IDBLayer _dBLayer;
    public DeviceLocationController(AppSettings appSettings, ILogger<DeviceController> logger, IDBLayer dBLayer)
    {
        _logger = logger;
        _appSettings = appSettings;
        _dBLayer = dBLayer;
    }

    [HttpGet]    
    [Route("device-location")]
    public async Task<IActionResult> GetDeviceLocation(string DeviceId)
    {
        var resp = _dBLayer.GetLocation(DeviceId);
        return Ok(resp);
    }

}