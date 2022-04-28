using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Services;

namespace Persona5APIv3.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PersonasDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<PersonasDbContext>>()
        ))
        {
            context.Database.EnsureCreated();
            if (context.PersonaEntities.Any())
            {
                return;
            }
            if (context.PersonaStats.Any())
            {
                return;
            }

            context.PersonaEntities.AddRange(
                new PersonaEntity
                {
                    Arcana = "Fool",
                    Description = "The starting persona for Joker in Persona 5.  He is based off the gentlemen thief from a Lupin novel.",
                    Level = 1,
                    Name = "Arsene",
                    Stats = new PersonaStatsEntity
                    {
                        Strength = 2,
                        Magic = 2,
                        Endurance = 2,
                        Agility = 3,
                        Luck = 1,
                        //PersonaRef = 1
                    },
                },
                new PersonaEntity
                {
                    Arcana = "Magician",
                    Description = "Description goes here",
                    Level = 2,
                    Name = "Jack-o'-Lantern",
                    Stats = new PersonaStatsEntity
                    {
                        Strength = 2,
                        Magic = 3,
                        Endurance = 3,
                        Agility = 3,
                        Luck = 2,
                        //PersonaRef = 2
                    }
                }
            );
            context.SaveChanges();

            context.PersonaStats.AddRange(
                new PersonaStatsEntity
                {
                    Strength = 2,
                    Magic = 2,
                    Endurance = 2,
                    Agility = 3,
                    Luck = 1,
                    //PersonaRef = 1
                },
                new PersonaStatsEntity
                {
                    Strength = 2,
                    Magic = 3,
                    Endurance = 3,
                    Agility = 3,
                    Luck = 2,
                    //PersonaRef = 2
                }
            );
            context.SaveChanges();
        }
    }
}