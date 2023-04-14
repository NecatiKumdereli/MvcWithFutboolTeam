using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _21660110053NecatiKumdereli.Models;

namespace _21660110053NecatiKumdereli.Controllers
{
    public class TeamController : Controller
    {
        private readonly FutbolTakımıContext _context;

        public TeamController()
        {
            _context = new FutbolTakımıContext();
        }

        // GET: Team
        public async Task<IActionResult> Index()
        {
              return _context.FootballTeams != null ? 
                          View(await _context.FootballTeams.ToListAsync()) :
                          Problem("Entity set 'FutbolTakımıContext.FootballTeams'  is null.");
        }

        // GET: Team/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.FootballTeams == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballTeam == null)
            {
                return NotFound();
            }

            return View(footballTeam);
        }

        // GET: Team/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShortName,EstablishDate,DirectorName,Captan,President")] FootballTeam footballTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footballTeam);
        }

        // GET: Team/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.FootballTeams == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeams.FindAsync(id);
            if (footballTeam == null)
            {
                return NotFound();
            }
            return View(footballTeam);
        }

        // POST: Team/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,ShortName,EstablishDate,DirectorName,Captan,President")] FootballTeam footballTeam)
        {
            if (id != footballTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballTeamExists(footballTeam.Id))
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
            return View(footballTeam);
        }

        // GET: Team/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.FootballTeams == null)
            {
                return NotFound();
            }

            var footballTeam = await _context.FootballTeams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballTeam == null)
            {
                return NotFound();
            }

            return View(footballTeam);
        }

        // POST: Team/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.FootballTeams == null)
            {
                return Problem("Entity set 'FutbolTakımıContext.FootballTeams'  is null.");
            }
            var footballTeam = await _context.FootballTeams.FindAsync(id);
            if (footballTeam != null)
            {
                _context.FootballTeams.Remove(footballTeam);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballTeamExists(long id)
        {
          return (_context.FootballTeams?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
