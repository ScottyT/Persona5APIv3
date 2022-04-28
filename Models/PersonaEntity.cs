using System.ComponentModel.DataAnnotations;
using Persona5APIv3.Interface;

namespace Persona5APIv3.Models;

public class PersonaEntity
{
    [Key]
    public int PersonaID { get; set; }
    public string? Name { get; set; }
    public int Level { get; set; }
    public string? Arcana { get; set; }
    public string? Description { get; set; }
    public PersonaStatsEntity? Stats { get; set; }
}