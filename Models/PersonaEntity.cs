using Persona5APIv3.Interface;

namespace Persona5APIv3.Models;

public class PersonaEntity : IEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; }
    public string? Arcana { get; set; }
    public PersonaStatsEntity? Stats { get; set; }
    public string? Description { get; set; }

    public int StatsID { get; set; }
}