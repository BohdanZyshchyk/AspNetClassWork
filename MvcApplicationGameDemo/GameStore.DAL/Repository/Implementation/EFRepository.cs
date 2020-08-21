using GameStore.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL.Repository.Implementation
{
    public class EFRepository<TEntity> : IGenericRepository<TEntity> where TEntity:class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> set;
        //Dependency Injection
        public EFRepository(DbContext _context)
        {
            context = _context;
            set = context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            set.Add(entity);
            Save();
        }

        public void Delete(TEntity entity)
        {
            set.Remove(entity);
            Save();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return set.AsEnumerable(); 
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    
    }
}
