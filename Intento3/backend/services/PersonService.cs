using backend.entities;
using backend.repositories;
using backend.services.interfaces;

namespace backend.services;

public class PersonService : IPersonService
{
  private readonly PersonRepository _personRepository;
  private readonly IPetService _petService;

  public PersonService(PersonRepository personRepository, IPetService petService)
  {
    _personRepository = personRepository;
    _petService = petService;
  }

  public async Task<List<Persona>> GetAll()
  {
    return await _personRepository.GetAll();
  }

  public async Task<Persona?> GetById(Guid id)
  {
    return await _personRepository.GetById(id);
  }

  public async Task<bool> Delete(Guid id)
  {
    var result = await _personRepository.Delete(id);
        
    if (result)
    {
      var pets = await _petService.GetByPersonId(id);
      var deleteTasks = pets.Select(pet => _petService.Delete(pet.Id));
      await Task.WhenAll(deleteTasks);
    }

    return result;
  }

  public async Task<Persona> Add(Persona entity)
  {
    return await _personRepository.Add(entity);
  }

  public async Task<Persona> Update(Guid id, Persona entity)
  {
    return await _personRepository.Update(id, entity);
  }
}