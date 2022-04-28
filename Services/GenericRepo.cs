using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Interface;

namespace Persona5APIv3.Services;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class, new()
{
    private readonly PersonasDbContext _personaContext;
    public GenericRepo(PersonasDbContext personaContext)
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

    /* public void Dispose()
    {
        if (_personaContext != null)
        {
            _personaContext.Dispose();
        }
    } */

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _personaContext.Set<TEntity>().ToListAsync();
        //throw new NotImplementedException();
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