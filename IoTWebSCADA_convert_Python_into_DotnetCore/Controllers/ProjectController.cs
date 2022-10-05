using IoTWebSCADA_convert_Python_into_DotnetCore.Database;
using IoTWebSCADA_convert_Python_into_DotnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private IoTWS_DbContext _IoTWS_DbContext;

        public ProjectController(IoTWS_DbContext iotws_DbContext)
        {
            _IoTWS_DbContext = iotws_DbContext;
        }

        //Read All List
        [HttpGet]
        public async Task<IEnumerable<Project>> Get()

            => await _IoTWS_DbContext.Projects.ToListAsync();

        //Search with Id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _IoTWS_DbContext.Projects.FindAsync(id);
            return project == null ? NotFound("Bu Id Değerinde Bir Project Yok.") : Ok(project);
        }

        //Search with ProjectName
        [HttpGet("search/{title}")]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitle(string name)
        {
            var project = await _IoTWS_DbContext.Projects.SingleOrDefaultAsync(c => c.ProjectName == name);
            return project == null ? NotFound("Bu İsimde Bir Project Yok.") : Ok(project);
        }
        //Project Add
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Project project)
        {
            await _IoTWS_DbContext.Projects.AddAsync(project);
            await _IoTWS_DbContext.SaveChangesAsync();
            //System.Diagnostics.Debug.WriteLine("veri: " + dev.DeviceIsActive);
            return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, project);
        }
        //Project Update
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Project project)
        {
            if (id != project.ProjectId) return BadRequest();
            _IoTWS_DbContext.Entry(project).State = EntityState.Modified;
            await _IoTWS_DbContext.SaveChangesAsync();

            return NoContent();
        }
        //Project Delete with Id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var PrjctDel = await _IoTWS_DbContext.Projects.FindAsync(id);
            if (PrjctDel == null) return NotFound();

            _IoTWS_DbContext.Projects.Remove(PrjctDel);
            await _IoTWS_DbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
