using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.Card;
using KP.BackEnd.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardCreateDto = KP.BackEnd.Areas.Supervisor.DTOs.Card.CardCreateDto;

namespace KP.BackEnd.Areas.Supervisor.Controllers
{
    [Authorize]
    [Area("Supervisor")]
    [ApiController]
    public class CardController :ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{studentId}/{date}/{range}")]
        public async Task<ActionResult<IEnumerable<CardGetDto>>> GetAll(Guid studentId, DateTime date, int range)
        {
            var cards = await _context.Cards
                .Where(x => x.StudentId == studentId && x.DueDate.Date.Subtract(date.Date).Days < range)
                .ToListAsync();
            
            return Ok(cards);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CardGetDto>> Get(Guid id)
        {
            var userId = Guid.Parse(User.Identity.Name);
            var card = await _context.Cards.Where(c => c.StudentId == userId && c.Id == id).FirstOrDefaultAsync();
            if (card == null)
                return NotFound("card not found");
            
            var cardDto = new CardGetDto(card, userId);
            return Ok(cardDto);
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CardCreateDto cardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = Guid.Parse(User.Identity.Name);
            var card = cardDto.ToCard(userId);
                
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
                
            return CreatedAtAction(nameof(Get), new CardGetDto(card, userId));
        }

    }
}