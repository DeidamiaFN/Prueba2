using AutoMapper;
using backend.dtos;
using backend.entities;
using backend.services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.controllers;

[Controller]
[Route("api/[controller]")]
public class PersonaControllers : ControllerBase
{
  private readonly IPersonService _personaService;
  private readonly IMapper _mapper;

  public PersonaControllers(IPersonService personaService, IMapper mapper)
  {
    _personaService = personaService;
    _mapper = mapper;
  }

  [HttpGet]
  public async Task<ActionResult<List<Persona>>> GetAll()
  {
    var personas = await _personaService.GetAll();
    var personasDto = _mapper.Map<List<Persona>>(personas);
    return Ok(personasDto);  
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Persona?>> GetPersona([FromRoute] Guid id)
  {
    var persona = await _personaService.GetById(id);
    var personaDto = _mapper.Map<Persona?>(persona);
    return Ok(personaDto);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult> DelPersona([FromRoute] Guid id)
  {
    var response = await _personaService.Delete(id);
    if (response)
      return NoContent();
    return Ok(response);
  }
  
  [HttpPost]
  public async Task<ActionResult<Persona>> AddPersona([FromBody] PersonaNoIdDto persona)
  {
    var personaEntity = _mapper.Map<Persona>((persona, Guid.NewGuid()));
    var newPersona = await _personaService.Add(personaEntity);
    var personaDto = _mapper.Map<Persona?>(newPersona);
    return CreatedAtAction(nameof(GetPersona), new {id = personaDto.Id}, personaDto);
  }
  
  [HttpPut("{id}")]
  public async Task<ActionResult<Persona>> UpdatePersona([FromRoute] Guid id, [FromBody] PersonaNoIdDto persona)
  {
    var newPersona = _mapper.Map<Persona>((persona, id));
    var updatedPersona = await _personaService.Update(id, newPersona);
    var personaDto = _mapper.Map<Persona?>(updatedPersona);
    return Ok(personaDto);
  }
}
