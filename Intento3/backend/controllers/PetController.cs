using AutoMapper;
using backend.dtos;
using backend.entities;
using backend.services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Controller]
[Route("api/[controller]")]
public class PetController : ControllerBase
{
  private readonly IPetService _petService;
  
  private readonly IMapper _mapper;

  public PetController(IPetService petService, IMapper mapper)
  {
    _petService = petService;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult<List<Pet>>> GetAll()
  {
    var pets = await _petService.GetAll();
    var petsDto = _mapper.Map<List<Pet>>(pets);
    return Ok(petsDto);  
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Pet?>> GetPet([FromRoute] Guid id)
  {
    var persona = await _petService.GetById(id);
    var personaDto = _mapper.Map<Pet?>(persona);
    return Ok(personaDto);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DelPet([FromRoute] Guid id)
  {
    var response = await _petService.Delete(id);
    if (response)
      return NoContent();
    return Ok(response);
  }
  
  [HttpPost]
  public async Task<ActionResult<Pet>> AddPet([FromBody] PetNoDto pet)
  {
    var personaEntity = _mapper.Map<Pet>((pet, Guid.NewGuid()));
    var newPersona = await _petService.Add(personaEntity);
    var personaDto = _mapper.Map<Pet?>(newPersona);
    return CreatedAtAction(nameof(GetPet), new {id = personaDto.Id}, personaDto);
  }
  
  [HttpPut("{id}")]
  public async Task<ActionResult<Pet>> UpdatePet([FromRoute] Guid id, [FromBody] PetNoDto pet)
  {
    var newPet = _mapper.Map<Pet>((pet, id));
    var updatedPersona = await _petService.Update(id, newPet);
    var personaDto = _mapper.Map<Pet?>(updatedPersona);
    return Ok(personaDto);
  }
}
