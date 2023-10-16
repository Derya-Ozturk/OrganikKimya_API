using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
                                                            where TEntity : class, IEntity, new()                                                           
                                                            where TContext : DbContext, new()
    {
        public int Add(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Add(entity);
            return context.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            using var context = new TContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            return context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                using var context = new TContext();
                TEntity response = context.Set<TEntity>().Where(filter).FirstOrDefault();
                return response;               
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IList GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new TContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public int Update(TEntity entity)
        {
            using var context = new TContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            return context.SaveChanges();
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().Any(filter);
        }
    }
}
