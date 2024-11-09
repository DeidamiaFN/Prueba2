using backend.entities;

namespace backend.repositories;

public class PersonRepository : AbstractRepository<Persona>
{

  public PersonRepository()
  {
    entities = new List<Persona>
    {
      new Persona()
      {
        Id = Guid.NewGuid(),
        Nombre = "Jose",
        FechaNacimiento = new DateTime(2015, 12, 31)
      },
      new Persona()
      {
        Id = Guid.NewGuid(),
        Nombre = "Dei",
        FechaNacimiento = new DateTime(2003, 10, 03)
      }
    };
  }

  public override Task<Persona> Update(Guid id, Persona entity)
  {
    var newPersona = entities.FirstOrDefault(p => p.Id == id);
    if (newPersona == null)
      return Task.FromResult(entity);
    
    newPersona.Nombre = entity.Nombre;
    newPersona.FechaNacimiento = entity.FechaNacimiento;
    
    return Task.FromResult(newPersona);  
  }
}
