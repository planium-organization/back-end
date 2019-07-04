using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Persistence.Repositories
{
    public class SchoolClassRepository : ISchoolClassRepository
    {
        private readonly ApplicationDbContext _context;

        public SchoolClassRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(SchoolClass schoolClass)
        {
            await _context.SchoolClasses.AddAsync((schoolClass));
        }
    }
}