using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace spotify_clone_backend.Repositories
{
    interface IRepositoryBase
    {
        public interface IRepositoryBase<T>
        {
            IQueryable<T> FindAll();
            void Create(T entity);
            void Update(T entity);
            void Delete(T entity);
            void SaveChanges();
        }
    }
}
