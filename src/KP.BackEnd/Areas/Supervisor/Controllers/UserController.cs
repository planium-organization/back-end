using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [ApiController, Route("api/[controller]/[action]"), Authorize]        
    public class UserController : Controller
    {        
        [HttpGet]
        public IActionResult Name()
        {   
            return Ok(User.Identity.Name);
        }
    }
}