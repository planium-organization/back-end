using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Core.Repositories;
using KP.BackEnd.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Persistence.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Card>> GetRange(Guid studentId, DateTime date, int range)
        {
            return await _context.Cards
                .Where(x => x.StudentId == studentId && x.DueDate.Date.Subtract(date.Date).Days < range)
                .ToListAsync();
        }

        public async Task<Card> Find(Guid userId, Guid id)
        {
            return await _context.Cards.Where(c => c.StudentId == userId && c.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Card card)
        {
            await _context.Cards.AddAsync(card);
        }
    }
}