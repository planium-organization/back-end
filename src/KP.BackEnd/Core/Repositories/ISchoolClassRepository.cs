using System;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.Repositories
{
    public interface ISchoolClassRepository
    {
        Task<SchoolClass> Find(Guid userId, Guid id);
        Task Add(SchoolClass schoolClass);
    }
}