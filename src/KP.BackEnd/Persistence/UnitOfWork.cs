using System.Threading.Tasks;
using KP.BackEnd.Core;
using KP.BackEnd.Core.Repositories;

namespace KP.BackEnd.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICardRepository Cards { get; private set; }
        
        public UnitOfWork(ApplicationDbContext context,ICardRepository cardRepository)
        {
            _context = context;
            Cards = cardRepository;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}