using IoTWebSCADA_convert_Python_into_DotnetCore.Database;
using IoTWebSCADA_convert_Python_into_DotnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceTelemetryController : ControllerBase
    {
        private IoTWS_DbContext _IoTWS_DbContext;

        public DeviceTelemetryController(IoTWS_DbContext iotws_DbContext)
        {
            _IoTWS_DbContext = iotws_DbContext;
        }

        // Find DeviceTelemetry with Id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DeviceTelemetry), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var devtel = await _IoTWS_DbContext.DeviceTelemetries.FindAsync(id);
            return devtel == null ? NotFound("Bu Id Değerinde Bir DeviceTelemetry Yok.") : Ok(devtel);
        }
        // Add DeviceTelemetry
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(DeviceTelemetry devtel)
        {
            await _IoTWS_DbContext.DeviceTelemetries.AddAsync(devtel);
            await _IoTWS_DbContext.SaveChangesAsync();
            //System.Diagnostics.Debug.WriteLine("veri: " + dev.DeviceIsActive);
            return CreatedAtAction(nameof(GetById), new { id = devtel.DeviceTelemetryId }, devtel);
        }
    }
}
