#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persona5APIv3.Data;
using Persona5APIv3.Models;

namespace Persona5APIv3.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonasDbContext _context;

        public PersonaController(PersonasDbContext context)
        {
            _context = context;
        }

        // GET: Persona
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonaEntities.ToListAsync());
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaEntity = await _context.PersonaEntities
                .FirstOrDefaultAsync(m => m.PersonaID == id);
            if (personaEntity == null)
            {
                return NotFound();
            }

            return View(personaEntity);
        }

        // GET: Persona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Persona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaID,Name,Level,Arcana,Description")] PersonaEntity personaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personaEntity);
        }

        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaEntity = await _context.PersonaEntities.FindAsync(id);
            if (personaEntity == null)
            {
                return NotFound();
            }
            return View(personaEntity);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonaID,Name,Level,Arcana,Description")] PersonaEntity personaEntity)
        {
            if (id != personaEntity.PersonaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaEntityExists(personaEntity.PersonaID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(personaEntity);
        }

        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personaEntity = await _context.PersonaEntities
                .FirstOrDefaultAsync(m => m.PersonaID == id);
            if (personaEntity == null)
            {
                return NotFound();
            }

            return View(personaEntity);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personaEntity = await _context.PersonaEntities.FindAsync(id);
            _context.PersonaEntities.Remove(personaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaEntityExists(int id)
        {
            return _context.PersonaEntities.Any(e => e.PersonaID == id);
        }
    }
}
