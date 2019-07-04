using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Persistence.Repositories
{
    public interface ISchoolClassRepository
    {
        Task Add(SchoolClass schoolClass);
    }
}