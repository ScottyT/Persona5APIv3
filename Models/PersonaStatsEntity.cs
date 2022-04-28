using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Interface;

namespace Persona5APIv3.Models;

public class PersonaStatsEntity
{
    [Key]
    public int StatsID {get; set;}
    public int Strength { get; set; }
    public int Magic { get; set; }
    public int Endurance { get; set; }
    public int Agility { get; set; }
    public int Luck { get; set; }
    //For Foreign key stuff
    /* public int PersonaRef {get; set;}
    public PersonaEntity? Persona {get; set;} */
}