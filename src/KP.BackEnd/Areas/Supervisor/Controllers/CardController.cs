using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Areas.Shared.DTOs.Card;
using KP.BackEnd.Areas.Student.DTOs.Card;
using KP.BackEnd.Data;
using KP.BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("{date}/{range}")]
        public async Task<ActionResult<IEnumerable<CardGetDto>>> GetAll(DateTime date, int range)
        {
            var cards = await _context.Cards.Where(x => x.DueDate.Date.Subtract(date.Date).Days < range).ToListAsync();
            
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CardGetDto>> Get(Guid id)
        {
            var card = await _context.Cards.FindAsync(id);

            return Ok(card);
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
                
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Edit(Guid id, [FromBody] JsonPatchDocument<CardPatchDto> cardDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var card = _context.Cards.Find(id);
            if (card == null)
                return NotFound("Card id is not valid");

            await _context.SaveChangesAsync();
            
            return Ok();
        }
        
    }
}