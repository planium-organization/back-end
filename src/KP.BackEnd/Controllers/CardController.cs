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
        public async Task<ActionResult<Card>> GetAll(DateTime date, int range)
        {
            var cards = await _context.Cards.Where(x => x.DueDate.Date.Subtract(date.Date).Days < range).ToListAsync();
            
            return Ok(cards);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> Get(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);

            return Ok(card);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CardDto cardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var card = new Card
            {
                Description = cardDto.Description,
                DueDate = cardDto.DueDate,
                Duration = cardDto.Duration,
                SupervisorCreated =  false,
                Type = CardType.Todo
            };
                
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
                
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] CardDto cardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var card = _context.Cards.Find(id);
            if (card == null)
                return NotFound("Card id is not valid");

            card.Type = cardDto.Type;

            await _context.SaveChangesAsync();
            
            return Ok();
        }
        
    }
}