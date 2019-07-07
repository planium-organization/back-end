using System;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Core.Repositories;

namespace KP.BackEnd.Persistence.Repositories
{
    public class SupervisorRepository : ISupervisorRepository
    {
        private readonly ApplicationDbContext _context;

        public SupervisorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Supervisor> Find(Guid id)
        {
            return await _context.Supervisors.FindAsync(id);
        }
    }
}