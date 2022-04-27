using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Services;

namespace Persona5APIv3.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using(var context = new PersonaContext(
            serviceProvider.GetRequiredService<DbContextOptions<PersonaContext>>()
        ))
        {
            if (context.PersonaEntities.Any())
            {
                return;
            }

            context.PersonaEntities.AddRange(
                new PersonaEntity
                {
                    Id = 1,
                    Arcana = "Fool",
                    Description = "The starting persona.",
                    Level = 1,
                    Name = "Arsene"
                }
            );
            context.SaveChanges();
        }
    }
}