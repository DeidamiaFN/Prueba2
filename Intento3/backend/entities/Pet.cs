namespace backend.entities;

public class Pet : Entity
{
  public Guid Id { get; set; }
  public Guid PersonId { get; set; }
  public string Name { get; set; }
  public string Species { get; set; }
}