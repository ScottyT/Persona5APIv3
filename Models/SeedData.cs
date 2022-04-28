using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Services;

namespace Persona5APIv3.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using(var context = new PersonasDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<PersonasDbContext>>()
        ))
        {
            if (context.PersonaEntity.Any())
            {
                return;
            }

            context.PersonaEntity.Add(
                new PersonaEntity
                {
                    Arcana = "Fool",
                    Description = "The starting persona for Joker in Persona 5.  He is based off the gentlemen thief from a Lupin novel.",
                    Level = 1,
                    Name = "Arsene",
                    Stats = new PersonaStatsEntity
                    {
                        Id = 1,
                        Strength = 2,
                        Magic = 2,
                        Endurance = 2,
                        Agility = 3,
                        Luck = 1
                    }
                }
            );
            context.SaveChanges();
        }
    }
}