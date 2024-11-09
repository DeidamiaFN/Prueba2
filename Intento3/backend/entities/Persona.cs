namespace backend.entities;

public class Persona : Entity
{
  public Guid Id { get; set; }
  public string Nombre { get; set; }
  public DateTime FechaNacimiento { get; set; }
}