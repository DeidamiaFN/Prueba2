using backend.entities;

namespace backend.services.interfaces;

public interface IPetService : IService<Pet>
{
  public Task<List<Pet>> GetByPersonId(Guid id);
}