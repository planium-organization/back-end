using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KP.BackEnd.Areas.Shared.Controllers
{
    [ApiController, Route("api/shared/[controller]/[action]"), Authorize]        
    public class UserController : Controller
    {        
        [HttpGet]
        public IActionResult Name()
        {   
            return Ok(User.Identity.Name);
        }
    }
}