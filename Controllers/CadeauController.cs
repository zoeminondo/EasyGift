using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyGift.Models;
using EasyGift.Views;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace EasyGift.Controllers
{
    public class CadeauController : Controller
    {
        private readonly EasyGiftContext _context;

        public CadeauController(EasyGiftContext context)
        {
            _context = context;
        }

        // GET: Cadeau
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cadeau.ToListAsync());
        }

        // GET: Cadeau/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadeau = await _context.Cadeau
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadeau == null)
            {
                return NotFound();
            }

            return View(cadeau);
        }

        // GET: Cadeau/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadeau/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CadeauPhotoView model)
        {
            if (ModelState.IsValid)
            {
                Cadeau cadeau = new Cadeau{
                    Id = model.Id,
                    titre = model.titre,
                    commentaire = model.commentaire,
                    marque = model.marque,
                    prix = model.prix,
                    photo = model.titre,
                    lien = model.lien,
                    dejaAchete = model.dejaAchete

                };
                _context.Add(cadeau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Cadeau/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadeau = await _context.Cadeau.FindAsync(id);
            if (cadeau == null)
            {
                return NotFound();
            }
            return View(cadeau);
        }

        // POST: Cadeau/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,titre,commentaire,marque,prix,lien,photo,dejaAchete")] Cadeau cadeau)
        {
            if (id != cadeau.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadeau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadeauExists(cadeau.Id))
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
            return View(cadeau);
        }
        public async Task<IActionResult> UploadImage(int Id, IFormFile file)
        {
            if (file == null){
                    return View();
            }
            
            // On va chercher toutes les informations sur ce cadeau id
            var cadeau = await _context.Cadeau
                .FirstOrDefaultAsync(m => m.Id == Id);

            if (cadeau == null)
            {
                return NotFound();
            }
            
            string adresseEasyGift = Directory.GetCurrentDirectory();
            using var image = Image.Load(file.OpenReadStream());
            image.Mutate(x => x.Resize(256, 256));   // Il faut changer le nom de la photo
            image.Save(adresseEasyGift+"/wwwroot/images/"+cadeau.titre+".jpg");
            // Il faut désormais modifier le nom dans la bdd pour que l'image se mette à jour 
            cadeau.photo = cadeau.titre+".jpg";
            _context.Update(cadeau);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
            
        }
        // GET: Cadeau/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadeau = await _context.Cadeau
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadeau == null)
            {
                return NotFound();
            }

            return View(cadeau);
        }

        // POST: Cadeau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadeau = await _context.Cadeau.FindAsync(id);
            _context.Cadeau.Remove(cadeau);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadeauExists(int id)
        {
            return _context.Cadeau.Any(e => e.Id == id);
        }
    }
}
