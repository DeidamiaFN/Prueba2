namespace backend.dtos;

public class PetDto
{
  public Guid Id { get; set; }
  public Guid PersonId { get; set; }
  public string Name { get; set; }
  public string Species { get; set; }
}