using System;
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

        public async Task<SchoolClass> Find(Guid id)
        {
            return await _context.SchoolClasses.FirstOrDefaultAsync(sc => sc.Id == id);
        }
        
        public async Task Add(SchoolClass schoolClass)
        {
            await _context.SchoolClasses.AddAsync((schoolClass));
        }
    }
}