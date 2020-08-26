using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repository.Abstraction
{
    // TEntity - це якась сутність з БД 
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity Find(int id);

        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);
    }
}
