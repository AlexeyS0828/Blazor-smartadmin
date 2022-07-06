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
    public class HorsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Horses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Horses.ToListAsync());
        }

        // GET: Horses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horses = await _context.Horses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horses == null)
            {
                return NotFound();
            }

            return View(horses);
        }

        // GET: Horses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Horses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ManagerID,Name,Sire,Dam,FoalDate,Country,Pedigree")] Horses horses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(horses);
        }

        // GET: Horses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horses = await _context.Horses.FindAsync(id);
            if (horses == null)
            {
                return NotFound();
            }
            return View(horses);
        }

        // POST: Horses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,ManagerID,Name,Sire,Dam,FoalDate,Country,Pedigree")] Horses horses)
        {
            if (id != horses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorsesExists(horses.Id))
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
            return View(horses);
        }

        // GET: Horses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horses = await _context.Horses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horses == null)
            {
                return NotFound();
            }

            return View(horses);
        }

        // POST: Horses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var horses = await _context.Horses.FindAsync(id);
            _context.Horses.Remove(horses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorsesExists(string id)
        {
            return _context.Horses.Any(e => e.Id == id);
        }
    }
}
