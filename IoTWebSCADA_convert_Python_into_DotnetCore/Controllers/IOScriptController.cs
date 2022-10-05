using IoTWebSCADA_convert_Python_into_DotnetCore.Database;
using IoTWebSCADA_convert_Python_into_DotnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IOScriptController : ControllerBase
    {

        private IoTWS_DbContext _IoTWS_DbContext;

        public IOScriptController(IoTWS_DbContext iotws_DbContext)
        {
            _IoTWS_DbContext = iotws_DbContext;
        }

        //Read All List
        [HttpGet]
        public async Task<IEnumerable<IOScript>> Get()

            => await _IoTWS_DbContext.IOScripts.ToListAsync();

        //Search with Id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOScript), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var ios = await _IoTWS_DbContext.IOScripts.FindAsync(id);
            return ios == null ? NotFound("Bu Id Değerinde Bir Connection Yok.") : Ok(ios);
        }

        //Search with MIOName
        [HttpGet("search/{mioname}")]
        [ProducesResponseType(typeof(IOScript), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitle(string mioname)
        {
            var ioscript = await _IoTWS_DbContext.IOScripts.SingleOrDefaultAsync(c => c.MasterIOName == mioname);
            return ioscript == null ? NotFound("Bu MION Cihazının Bir Connectionu Yok.") : Ok(ioscript);
        }
        //Connection Add
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(IOScript ioscript)
        {
            await _IoTWS_DbContext.IOScripts.AddAsync(ioscript);
            await _IoTWS_DbContext.SaveChangesAsync();
            //System.Diagnostics.Debug.WriteLine("veri: " + dev.DeviceIsActive);
            return CreatedAtAction(nameof(GetById), new { id = ioscript.IOScriptId }, ioscript);
        }
        //Connection Update
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, IOScript ioscript)
        {
            if (id != ioscript.IOScriptId) return BadRequest();
            _IoTWS_DbContext.Entry(ioscript).State = EntityState.Modified;
            await _IoTWS_DbContext.SaveChangesAsync();

            return NoContent();
        }
        //Connection Delete with Id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var ConnDel = await _IoTWS_DbContext.IOScripts.FindAsync(id);
            if (ConnDel == null) return NotFound();

            _IoTWS_DbContext.IOScripts.Remove(ConnDel);
            await _IoTWS_DbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
