namespace backend.services.interfaces;

public interface IService<T>
{
  public Task<List<T>> GetAll();
  public Task<T?> GetById(Guid id);
  public Task<bool> Delete(Guid id);
  public Task<T?> Add(T entity);
  public Task<T> Update(Guid id, T entity);
}