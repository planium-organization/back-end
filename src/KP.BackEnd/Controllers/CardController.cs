using System;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Data;
using KP.BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardController :ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("{date}/{range}")]
        public async Task<ActionResult<Post>> GetAll(DateTime date, int range)
        {
            var cards = await _context.Cards.Where(x => x.DueDate.Date.Subtract(date.Date).Days < range).ToListAsync();
            
            return Ok(cards);
        }
        
    }
}