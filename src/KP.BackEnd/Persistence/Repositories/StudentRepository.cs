using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Core.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Student>> FindAll(Guid classId)
        {
            return await _context.Students.Where(s => s.SchoolClass.Id == classId).ToListAsync();
        }
    }
}