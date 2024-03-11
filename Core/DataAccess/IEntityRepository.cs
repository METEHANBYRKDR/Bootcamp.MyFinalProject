using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess;

// generic constraint
// IEntity veya IEntity İmplementasyonlarını alabilir.
// IEntity newlenemiyiceği için IEntity koyamayız
public interface IEntityRepository<T> where T : class,IEntity, new()
{
    List<T> GetAll(Expression<Func<T,bool>> filter = null);
    T Get(Expression<Func<T,bool>> filter);

    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
