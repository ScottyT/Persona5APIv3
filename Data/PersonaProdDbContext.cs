using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persona5APIv3.Data;

public class PersonaProdDbContext : DbContext
{
    protected readonly IConfiguration _configuration;
    public PersonaProdDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("PersonaProdContext"));
    }
}