using System;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Core.Repositories;

namespace KP.BackEnd.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Find(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }
    }
}