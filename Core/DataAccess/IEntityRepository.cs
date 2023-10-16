using Core.Entities;
using System.Collections;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);
        IList GetList(Expression<Func<T, bool>> filter = null);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        bool Any(Expression<Func<T, bool>> filter = null);
    }
}
