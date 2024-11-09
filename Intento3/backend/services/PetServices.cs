using backend.entities;
using backend.repositories;
using backend.services.interfaces;

namespace backend.services;

public class PetServices : IPetService
{
  private readonly PetRepository _petRepository;

  public PetServices(PetRepository petRepository)
  {
    _petRepository = petRepository;
  }

  public async Task<List<Pet>> GetAll()
  {
    return await _petRepository.GetAll();
  }

  public async Task<Pet?> GetById(Guid id)
  {
    return await _petRepository.GetById(id);
  }

  public async Task<bool> Delete(Guid id)
  {
    return await _petRepository.Delete(id);
  }

  public async Task<Pet?> Add(Pet entity)
  {
    return await _petRepository.Add(entity);
  }

  public async Task<Pet> Update(Guid id, Pet entity)
  {
    return await _petRepository.Update(id, entity);
  }

  public async Task<List<Pet>> GetByPersonId(Guid id)
  {
    return await _petRepository.GetByPersonId(id);
  }
}