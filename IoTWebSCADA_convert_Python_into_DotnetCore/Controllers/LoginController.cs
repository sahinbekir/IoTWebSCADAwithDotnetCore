using IoTWebSCADA_convert_Python_into_DotnetCore.Database;
using IoTWebSCADA_convert_Python_into_DotnetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTWebSCADA_convert_Python_into_DotnetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IoTWS_DbContext _IoTWS_DbContext;
        public LoginController(IoTWS_DbContext iotws_DbContext)
        {
            _IoTWS_DbContext = iotws_DbContext;
        }

        //Search with Name
        [HttpGet("{login}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitle(string username, string password)
        {
            var user = await _IoTWS_DbContext.Users.SingleOrDefaultAsync(c => c.UserName == username && c.UserPassword == password);
            return user == null ? NotFound("Böyle Bir Kullanıcı Bulunamadı...") : Ok(user);
        }
    }
}
