using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.Repositories
{
    public interface ISchoolClassRepository
    {
        Task<SchoolClass> Find(Guid userId, Guid id);
        Task Add(SchoolClass schoolClass);
        Task<IEnumerable<SchoolClass>> GetAll(Guid userId);
    }
}