using IoTWebSCADA_convert_Python_into_DotnetCore.Database;
using IoTWebSCADA_convert_Python_into_DotnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceAlertTelemetryController : ControllerBase
    {
        private IoTWS_DbContext _IoTWS_DbContext;

        public DeviceAlertTelemetryController(IoTWS_DbContext iotws_DbContext)
        {
            _IoTWS_DbContext = iotws_DbContext;
        }

        //Read All List
        [HttpGet]
        public async Task<IEnumerable<DeviceAlertTelemetry>> Get()

            => await _IoTWS_DbContext.DeviceAlertTelemetries.ToListAsync();

        
    }
}
