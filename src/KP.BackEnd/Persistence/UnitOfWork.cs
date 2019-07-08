using System.Threading.Tasks;
using KP.BackEnd.Core;
using KP.BackEnd.Core.Repositories;

namespace KP.BackEnd.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICardRepository Cards { get; private set; }
        public  ICommentRepository Comments { get; private set; }
        public  ISchoolClassRepository SchoolClasses { get; private set; }
        public  IChannelPostRepository ChannelPosts { get; private set; }
        public IStudentRepository Students { get; private set; }
        public ISupervisorRepository Supervisors { get; private set; }
        
        public UnitOfWork(ApplicationDbContext context,
            ICardRepository cardRepository,
            ICommentRepository commentRepository,
            ISchoolClassRepository schoolClassRepository,
            IChannelPostRepository channelPostRepository,
            ISupervisorRepository supervisorRepository,
            IStudentRepository studentRepository)
        {
            _context = context;
            
            Cards = cardRepository;
            Comments = commentRepository;
            ChannelPosts = channelPostRepository;
            SchoolClasses = schoolClassRepository;
            Supervisors = supervisorRepository;
            Students = studentRepository;
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}