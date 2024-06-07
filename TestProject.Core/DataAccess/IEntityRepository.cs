using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestProject.Core.Entities;

namespace TestProject.Core.DataAccess
{
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);
    }
}
