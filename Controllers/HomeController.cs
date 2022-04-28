#nullable disable
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Persona5APIv3.Interface;
using Persona5APIv3.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq.Expressions;
using Persona5APIv3.Services;

namespace Persona5APIv3.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly PersonasDbContext _context;
    private readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, PersonasDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var personas = await _context.PersonaEntities.Include(x => x.Stats).ToListAsync();
        var personasDTO = personas.Select(e => _mapper.Map<PersonaEntity, PersonaDTO>(e)).ToList();
        return View(personas);
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
