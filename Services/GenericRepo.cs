using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Interface;

namespace Persona5APIv3.Services;

public class GenericRepo<TEntity> : IGenericRepo<TEntity>, IDisposable where TEntity : class, IEntity
{
    private readonly PersonaContext _personaContext;
    public GenericRepo(PersonaContext personaContext)
    {
        _personaContext = personaContext;
    }

    public Task Create(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _personaContext.Set<TEntity>().ToListAsync();
    }

    public Task<IEnumerable<TEntity>> GetAllIncluding(Expression<Func<TEntity, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    public TEntity GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(int id, TEntity entity)
    {
        throw new NotImplementedException();
    }
}