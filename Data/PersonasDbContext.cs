#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Models;

    public class PersonasDbContext : DbContext
    {
        public PersonasDbContext (DbContextOptions<PersonasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Persona5APIv3.Models.PersonaEntity> PersonaEntity { get; set; }
        public DbSet<PersonaStatsEntity> PersonaStats {get; set;}

        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonaEntity>().ToTable("PersonaEntity");
            modelBuilder.Entity<PersonaStatsEntity>().ToTable("PersonaStats");
            
        } */
    }
