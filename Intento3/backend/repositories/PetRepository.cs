using backend.entities;

namespace backend.repositories;

public class PetRepository : AbstractRepository<Pet>
{

  public PetRepository()
  {
    entities = new List<Pet>
    {
      new Pet()
      {
        Name = "Batman",
        Id = Guid.NewGuid(),
        PersonId = Guid.NewGuid(),
        Species = "Cat"
      },
      new Pet()
      {
        Name = "Bola de nieve",
        Id = Guid.NewGuid(),
        PersonId = Guid.NewGuid(),
        Species = "Cat"
      }
    };
  }


  public override Task<Pet> Update(Guid id, Pet entity)
  {
    var newPet = entities.FirstOrDefault(p => p.Id == id);
    if (newPet == null)
      return Task.FromResult(entity);
    
    newPet.Name = entity.Name;
    newPet.Species = entity.Species;
    newPet.PersonId = entity.PersonId;
    
    return Task.FromResult(newPet);  
  }

  public Task<List<Pet>> GetByPersonId(Guid id)
  {
    var pets = entities.Where(p => p.PersonId == id).ToList();
    return Task.FromResult(pets);
  }
}