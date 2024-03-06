using Entities.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract;

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
