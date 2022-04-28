using System.Linq.Expressions;
using Persona5APIv3.Interface;

namespace Persona5APIv3.Interface;

public interface IGenericRepo<TEntity>
{
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAllIncluding(
        Expression<Func<TEntity, bool>> filter = null,
        string includedProperties = "");
    TEntity GetById(int id);
    Task Create(TEntity entity);
    Task Update(int id, TEntity entity);
    Task Delete(int id);
}