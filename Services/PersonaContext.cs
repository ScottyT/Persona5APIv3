using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Models;

namespace Persona5APIv3.Services;

public class PersonaContext : DbContext
{
    public PersonaContext(DbContextOptions<PersonaContext> options) : base(options)
    {

    }

    public DbSet<PersonaEntity> PersonaEntities { get; set; }
    //public DbSet<PersonaStatsEntity> PersonaStats { get; set; }

    /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonaEntity>().ToTable("Persona");
        modelBuilder.Entity<PersonaStatsEntity>().ToTable("PersonaStatsEntity");
    } */
}