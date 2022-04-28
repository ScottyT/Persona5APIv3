#nullable disable
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Persona5APIv3.Interface;
using Persona5APIv3.Models;
using Microsoft.EntityFrameworkCore;

namespace Persona5APIv3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGenericRepo<PersonaEntity> _persona;
    private readonly PersonasDbContext _context;

    public HomeController(ILogger<HomeController> logger, IGenericRepo<PersonaEntity> persona, PersonasDbContext context)
    {
        _logger = logger;
        _persona = persona;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        //return View(await _persona.GetAll());
        return View(await _context.PersonaEntities.Include(x => x.Stats).ToListAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
