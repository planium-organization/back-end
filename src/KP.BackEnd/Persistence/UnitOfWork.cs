using System.Threading.Tasks;
using KP.BackEnd.Data;
using KP.BackEnd.Repositories;

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
            _context.SaveChanges();
        }
    }
}