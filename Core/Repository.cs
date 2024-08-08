using Core;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class Repository<TEntity, Tcontext> : IRepository<TEntity>
    where TEntity : class, IBaseEntity, new()
    where Tcontext : DbContext, new()
{
    public void Add(TEntity entity)
    {
        using (var context = new Tcontext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        using (var context = new Tcontext())
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }

    public void DeleteById(int id)
    {
        using (var context = new Tcontext())
        {
            var entity = context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
    }

    public IEnumerable<TEntity> GetAll()
    {
        using (var context = new Tcontext())
        {
            return context.Set<TEntity>().ToList();
        }
    }

    public TEntity GetById(int id)
    {
        using (var context = new Tcontext())
        {
            return context.Set<TEntity>().Find(id);
        }
    }

    public void Update(TEntity entity)
    {
        using (var context = new Tcontext())
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (var context = new Tcontext())
        {
            return context.Set<TEntity>().FirstOrDefault(filter);
        }
    }
}

