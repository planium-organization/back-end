using System.Threading.Tasks;
using KP.BackEnd.Core;
using KP.BackEnd.Core.Repositories;
using KP.BackEnd.Persistence.Data;

namespace KP.BackEnd.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICardRepository Cards { get; private set; }
        public  ICommentRepository Comments { get; private set; }
        public  IChannelPostRepository ChannelPosts { get; private set; }
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}