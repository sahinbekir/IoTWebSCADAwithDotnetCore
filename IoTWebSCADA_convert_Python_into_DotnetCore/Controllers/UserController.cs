using IoTWebSCADA_convert_Python_into_DotnetCore.Database;
using IoTWebSCADA_convert_Python_into_DotnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IoTWS_DbContext _IoTWS_DbContext;
        public UserController(IoTWS_DbContext iotws_DbContext)
        {
            _IoTWS_DbContext = iotws_DbContext;
        }

        //Read All List
        [HttpGet]
        public async Task<IEnumerable<User>> Get()

            => await _IoTWS_DbContext.Users.ToListAsync();

        //Search with Id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _IoTWS_DbContext.Users.FindAsync(id);
            return user == null ? NotFound("Bu Id Değerinde Bir Kullanıcı Yok.") : Ok(user);
        }

        //Search with Name
        [HttpGet("search/{title}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitle(string userfirstname, string userlastname)
        {
            var user = await _IoTWS_DbContext.Users.SingleOrDefaultAsync(c => c.UserFirstName==userfirstname && c.UserLastName == userlastname);
            return user == null ? NotFound("Bu Ad ve Soyad Değerinde Bir Kullanıcı Yok.") : Ok(user);
        }
        //User Add
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(User user)
        {
            await _IoTWS_DbContext.Users.AddAsync(user);
            await _IoTWS_DbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }
        //User Update
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.UserId) return BadRequest();
            _IoTWS_DbContext.Entry(user).State = EntityState.Modified;
            await _IoTWS_DbContext.SaveChangesAsync();

            return NoContent();
        }
        //User Delete with Id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var UserDel = await _IoTWS_DbContext.Users.FindAsync(id);
            if (UserDel == null) return NotFound();

            _IoTWS_DbContext.Users.Remove(UserDel);
            await _IoTWS_DbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
