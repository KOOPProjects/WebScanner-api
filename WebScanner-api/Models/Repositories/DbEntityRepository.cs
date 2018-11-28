using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebScanner_api.Models.Database;
using WebScanner_api.Models.Repositories.Interfaces;

namespace WebScanner_api.Models.Repositories
{
    public abstract class DbEntityRepository<TEntity> : IRepository<TEntity> where TEntity : DbEntity
    {
        protected readonly DatabaseContext DatabaseContext;

        protected DbEntityRepository(DatabaseContext databaseContext)
        {
            this.DatabaseContext = databaseContext;
        }

        public virtual void Add(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DatabaseContext.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual TEntity Get(int id)
        {
            return DatabaseContext.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DatabaseContext.Set<TEntity>().ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            this.DatabaseContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.DatabaseContext.Set<TEntity>().Update(entity);
        }
    }
}
