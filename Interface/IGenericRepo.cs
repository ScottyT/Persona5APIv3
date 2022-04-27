using System.Linq.Expressions;
using Persona5APIv3.Interface;

namespace Persona5APIv3.Interface;

public interface IGenericRepo<TEntity> where TEntity : class, IEntity
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAllIncluding(Expression<Func<TEntity, object>>[] includeProperties);
    TEntity GetById(int id);
    Task Create(TEntity entity);
    Task Update(int id, TEntity entity);
    Task Delete(int id);
}