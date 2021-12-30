using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyGift.Models;

namespace EasyGift.Controllers
{
    public class ListeController : Controller
    {
        private readonly EasyGiftContext _context;

        public ListeController(EasyGiftContext context)
        {
            _context = context;
        }

        // GET: Liste
        public async Task<IActionResult> Index()
        {
            return View(await _context.Liste.ToListAsync());
        }

        // GET: Liste/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cadeau = await _context.Cadeau.Where(m => m.listeId == id).ToListAsync();
            if (cadeau == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index","Cadeau",new{idListe=id});
        }

        // GET: Liste/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Liste/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nomListe")] Liste liste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(liste);
        }

        // GET: Liste/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liste = await _context.Liste.FindAsync(id);
            if (liste == null)
            {
                return NotFound();
            }
            return View(liste);
        }

        // POST: Liste/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nomListe")] Liste liste)
        {
            if (id != liste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListeExists(liste.Id))
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
            return View(liste);
        }

        // GET: Liste/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liste = await _context.Liste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liste == null)
            {
                return NotFound();
            }

            return View(liste);
        }

        // POST: Liste/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liste = await _context.Liste.FindAsync(id);
            var cadeau = await _context.Cadeau.Where(m => m.listeId == id).ToListAsync();
            foreach(var c in cadeau){
                c.listeId = null;
                _context.Update(c);
            }
            _context.Liste.Remove(liste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListeExists(int id)
        {
            return _context.Liste.Any(e => e.Id == id);
        }
    }
}
