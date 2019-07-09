using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Persistence.Repositories
{
    public class SchoolClassRepository : ISchoolClassRepository
    {
        private readonly ApplicationDbContext _context;

        public SchoolClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SchoolClass> Find(Guid userId, Guid id)
        {
            return await _context.SchoolClasses.FirstOrDefaultAsync(sc => sc.Id == id && sc.SupervisorId == userId);
        }
        
        public async Task Add(SchoolClass schoolClass)
        {
            await _context.SchoolClasses.AddAsync((schoolClass));
        }

        public async Task<IEnumerable<SchoolClass>> GetAll(Guid userId)
        {
            return await _context.SchoolClasses.Where(sc => sc.SupervisorId == userId).ToListAsync();
        }

        public async Task<SchoolClass> FindByToken(string token)
        {
            return await _context.SchoolClasses.FirstOrDefaultAsync(s => s.Token == token);
        }
    }
}