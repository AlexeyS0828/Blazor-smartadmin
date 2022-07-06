using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Data;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Controllers
{
    public class SyndicatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SyndicatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Syndicates
        public async Task<IActionResult> Index()
        {
            return View(await _context.Syndicates.ToListAsync());
        }

        // GET: Syndicates/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syndicates = await _context.Syndicates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (syndicates == null)
            {
                return NotFound();
            }

            return View(syndicates);
        }

        // GET: Syndicates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Syndicates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManagerID,Name,DateCreated,Status")] Syndicates syndicates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(syndicates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(syndicates);
        }

        // GET: Syndicates/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syndicates = await _context.Syndicates.FindAsync(id);
            if (syndicates == null)
            {
                return NotFound();
            }
            return View(syndicates);
        }

        // POST: Syndicates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ManagerID,Name,DateCreated,Status")] Syndicates syndicates)
        {
            if (id != syndicates.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(syndicates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SyndicatesExists(syndicates.Id))
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
            return View(syndicates);
        }

        // GET: Syndicates/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syndicates = await _context.Syndicates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (syndicates == null)
            {
                return NotFound();
            }

            return View(syndicates);
        }

        // POST: Syndicates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var syndicates = await _context.Syndicates.FindAsync(id);
            _context.Syndicates.Remove(syndicates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SyndicatesExists(string id)
        {
            return _context.Syndicates.Any(e => e.Id == id);
        }
    }
}
