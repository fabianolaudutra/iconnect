using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Iconnect.Infraestrutura.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<IQueryable<T>> Find(Expression<Func<T, bool>> exp);
        EntityEntry<T> Attach(T entity);
        Task<IQueryable<T>> Find();
        void Delete(T entity);
        void Insert(T entity);
        void Update(T entity);
        Task<T> GetAsync(Guid id);
        Task<int> SaveAsync();
        //Task<T> ExecuteSQL(string query);
    }
}
