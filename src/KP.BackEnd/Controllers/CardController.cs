using System;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Data;
using KP.BackEnd.DTOs;
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CardDto cardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var card= new Card
            {
                Description = cardDto.Description,
                DueDate = cardDto.DueDate,
                Duration = cardDto.Duration,
                SupervisorCreated =  false,
                Type= CardType.Todo
            };
                
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
                
            return Ok();
        }

    }
}