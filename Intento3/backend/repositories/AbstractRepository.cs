using backend.entities;

namespace backend.repositories;

public abstract class AbstractRepository<T> : IRepository<T> where T : Entity
{
  protected List<T> entities;

  public Task<List<T>> GetAll()
  {
    return Task.FromResult(entities);
  }

  public Task<T?> GetById(Guid id)
  {
    var entity = entities.FirstOrDefault(x => x.Id == id);
    return Task.FromResult(entity);
  }

  public Task<bool> Delete(Guid id)
  {
    var entity = entities.FirstOrDefault(p => p.Id == id);
    if (entity == null)
      return Task.FromResult(false);
    
    entities.Remove(entity);
    return Task.FromResult(true);
  }

  public Task<T> Add(T entity)
  {
    entities.Add(entity);
    return Task.FromResult(entity);
  }

  public abstract Task<T> Update(Guid id, T entity);
}