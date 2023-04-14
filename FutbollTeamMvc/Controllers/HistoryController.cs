﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _21660110053NecatiKumdereli.Models;

namespace _21660110053NecatiKumdereli.Controllers
{
    public class HistoryController : Controller
    {
        private readonly FutbolTakımıContext _context;

        public HistoryController()
        {
            _context = new FutbolTakımıContext();
        }

       

        // GET: History
        public async Task<IActionResult> Index()
        {
            var futbolTakımıContext = _context.FootballPlayerHistories.Include(f => f.Player).Include(f => f.Team);
            return View(await futbolTakımıContext.ToListAsync());
        }

        // GET: History/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.FootballPlayerHistories == null)
            {
                return NotFound();
            }

            var footballPlayerHistory = await _context.FootballPlayerHistories
                .Include(f => f.Player)
                .Include(f => f.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballPlayerHistory == null)
            {
                return NotFound();
            }

            return View(footballPlayerHistory);
        }

        // GET: History/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.FootballPlayers, "Id", "Id");
            ViewData["TeamId"] = new SelectList(_context.FootballTeams, "Id", "Id");
            return View();
        }

        // POST: History/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlayerId,TeamId")] FootballPlayerHistory footballPlayerHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(footballPlayerHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.FootballPlayers, "Id", "Id", footballPlayerHistory.PlayerId);
            ViewData["TeamId"] = new SelectList(_context.FootballTeams, "Id", "Id", footballPlayerHistory.TeamId);
            return View(footballPlayerHistory);
        }

        // GET: History/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.FootballPlayerHistories == null)
            {
                return NotFound();
            }

            var footballPlayerHistory = await _context.FootballPlayerHistories.FindAsync(id);
            if (footballPlayerHistory == null)
            {
                return NotFound();
            }
            ViewData["PlayerId"] = new SelectList(_context.FootballPlayers, "Id", "Id", footballPlayerHistory.PlayerId);
            ViewData["TeamId"] = new SelectList(_context.FootballTeams, "Id", "Id", footballPlayerHistory.TeamId);
            return View(footballPlayerHistory);
        }

        // POST: History/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PlayerId,TeamId")] FootballPlayerHistory footballPlayerHistory)
        {
            if (id != footballPlayerHistory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footballPlayerHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootballPlayerHistoryExists(footballPlayerHistory.Id))
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
            ViewData["PlayerId"] = new SelectList(_context.FootballPlayers, "Id", "Id", footballPlayerHistory.PlayerId);
            ViewData["TeamId"] = new SelectList(_context.FootballTeams, "Id", "Id", footballPlayerHistory.TeamId);
            return View(footballPlayerHistory);
        }

        // GET: History/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.FootballPlayerHistories == null)
            {
                return NotFound();
            }

            var footballPlayerHistory = await _context.FootballPlayerHistories
                .Include(f => f.Player)
                .Include(f => f.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (footballPlayerHistory == null)
            {
                return NotFound();
            }

            return View(footballPlayerHistory);
        }

        // POST: History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.FootballPlayerHistories == null)
            {
                return Problem("Entity set 'FutbolTakımıContext.FootballPlayerHistories'  is null.");
            }
            var footballPlayerHistory = await _context.FootballPlayerHistories.FindAsync(id);
            if (footballPlayerHistory != null)
            {
                _context.FootballPlayerHistories.Remove(footballPlayerHistory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootballPlayerHistoryExists(long id)
        {
          return (_context.FootballPlayerHistories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
