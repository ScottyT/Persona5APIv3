namespace Persona5APIv3.Models;

public class PersonaDTO
{
    public string? Name { get; set; }
    public int Level { get; set; }
    public string? Arcana { get; set; }
    public PersonaStatsDTO? Stats {get; set;}
    public string Description { get; set; }
}