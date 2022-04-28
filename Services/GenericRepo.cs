using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Interface;

namespace Persona5APIv3.Services;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
{
    internal PersonasDbContext _personaContext;
    internal DbSet<TEntity> dbSet;
    //private readonly IMapper _mapper;
    public GenericRepo(PersonasDbContext personaContext)
    {
        this._personaContext = personaContext;
        this.dbSet = personaContext.Set<TEntity>();
    }

    public Task Create(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _personaContext.Set<TEntity>().ToListAsync();
        //throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllIncluding(
        Expression<Func<TEntity, bool>> filter, string includedProperties = "")
    {
        IQueryable<TEntity> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var prop in includedProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(prop);
        }
        return await query.ToListAsync();
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