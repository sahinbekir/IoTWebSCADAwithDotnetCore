using IoTWebSCADA_convert_Python_into_DotnetCore.Database;
using IoTWebSCADA_convert_Python_into_DotnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private IoTWS_DbContext _IoTWS_DbContext;

        public DeviceController(IoTWS_DbContext iotws_DbContext)
        {
            _IoTWS_DbContext = iotws_DbContext;
        }

        //Read All List
        [HttpGet]
        public async Task<IEnumerable<Device>> Get()

            => await _IoTWS_DbContext.Devices.ToListAsync();

        //Search with UID
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Device), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)    
        {
            var device = await _IoTWS_DbContext.Devices.FindAsync(id);
            return device == null ? NotFound("Bu Id Değerinde Bir Device Yok.") : Ok(device);
        }

        //Search with UserId
        [HttpGet("search/{uid}")]
        [ProducesResponseType(typeof(Device), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitle(string deviceuid)
        {
            var device = await _IoTWS_DbContext.Devices.SingleOrDefaultAsync(c => c.DeviceUID == deviceuid);
            return device == null ? NotFound("Bu UID'nin Sahip Olduğu Cihaz Yok.") : Ok(device);
        }
        //Device Add
        //TO DO: KAYIT SIRASINDA OLAN 500 HATASI BAD-RESPONSE SEBEBİ
        //TEMEL KAYNAĞI BOOL VERİ GİRİŞİ: KAYIT GERÇEKLEŞİYOR SORUNSUZ AMA FRONTEND TARAFINDA BU HATAYI FIRLATIYOR.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Device dev)
        {
            await _IoTWS_DbContext.Devices.AddAsync(dev);
            await _IoTWS_DbContext.SaveChangesAsync();
            //System.Diagnostics.Debug.WriteLine("veri: " + dev.DeviceIsActive);
            return CreatedAtAction(nameof(GetById), new { id = dev.DeviceId }, dev);
        }
        //Device Update
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Device dev)
        {
            if (id != dev.DeviceId) return BadRequest();
            _IoTWS_DbContext.Entry(dev).State = EntityState.Modified;
            await _IoTWS_DbContext.SaveChangesAsync();

            return NoContent();
        }
        //Device Delete with Id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var DevDel = await _IoTWS_DbContext.Devices.FindAsync(id);
            if (DevDel == null) return NotFound();

            _IoTWS_DbContext.Devices.Remove(DevDel);
            await _IoTWS_DbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
