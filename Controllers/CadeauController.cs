using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;  
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
        public async Task<IActionResult> Index(int? idListe)
        {
            if(idListe==null){
                return View(await _context.Cadeau.ToListAsync());
            }
            var cadeau = await _context.Cadeau.Where(m => m.listeId == idListe).ToListAsync();
            if(cadeau ==null){
                return View();
            }
            else{
                return View(cadeau);
            }
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
        public IActionResult Create(int? idListe)
        {
            var liste = _context.Liste;
            var viewModel = new List<Liste>();
            
            foreach(var l in liste){
                viewModel.Add(new Liste{
                    Id = l.Id,
                    nomListe = l.nomListe
                });
            }
            ViewData["Liste"] = viewModel;
            
            return View();
        }

        // POST: Cadeau/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, CadeauPhotoView model)
        {
           /* Console.WriteLine("Id="+model.Id+" cadeau="+model.titre+" commentaire="+model.commentaire+" marque="+model.marque+" prix="+model.prix+
            " lien="+model.lien+" photo="+model.photoTel+" dejaAchete="+model.dejaAchete);
        */
            if (ModelState.IsValid)
            {
                Cadeau cadeau = new Cadeau{
                    Id = model.Id,
                    titre = model.titre,
                    commentaire = model.commentaire,
                    marque = model.marque,
                    prix = model.prix,
                    lien = model.lien,
                    dejaAchete = model.dejaAchete,
                    listeId = model.listeId

                };
                if(UploadImage(model.photoTel, model.titre)){
                    cadeau.photo = model.titre+".jpg";
                }
                else{
                    cadeau.photo = "none.jpg";
                }

                _context.Add(cadeau);
                await _context.SaveChangesAsync();
                Console.WriteLine("ca me redirec tou");
                return RedirectToAction(nameof(Index));
            }
                Console.WriteLine("ca me redirec qdq");

            return View();
        }

        // GET: Cadeau/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Besoin de mettre un ViewData pour avoir accès à toutes les listes depuis le ViewCadeau
            var liste = _context.Liste;
            var viewModel = new List<Liste>();
            
            foreach(var l in liste){
                viewModel.Add(new Liste{
                    Id = l.Id,
                    nomListe = l.nomListe
                });
            }
            ViewData["Liste"] = viewModel;

            
            var cadeau = await _context.Cadeau.FindAsync(id);
            if (cadeau == null)
            {
                return NotFound();
            }
          
            if (id == null)
            {
                return NotFound();
            }
            // Besoin de récupérer l'idListe de base pour le préséléctionner
            ViewData["idListe"] = cadeau.listeId;
            return View(cadeau);
        }

        // POST: Cadeau/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cadeau cad)
        {
           
            if (id != cad.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                if(cad.listeId != null){
                    Console.WriteLine("testion");
                    var liste = await _context.Liste.FirstOrDefaultAsync(m => m.Id == cad.listeId);
                    cad.listeCadeau = liste;
                }
                try
                {
                    _context.Update(cad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadeauExists(cad.Id))
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
            return View(cad);
        }
        public async Task<IActionResult> ModifierImage (IFormFile file, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cadeau = await _context.Cadeau.FirstOrDefaultAsync(m => m.Id == id);
            if (cadeau == null)
            {

                return NotFound();
            }

            if(UploadImage(file, id.ToString())){
                    cadeau.photo = id.ToString()+".jpg";

                }
                else{
                    cadeau.photo = "none.jpg";
                }
             _context.Update(cadeau);
                    await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
            
            
        }
        public bool UploadImage(IFormFile file, string titre)
        {
            // On va chercher toutes les informations sur ce cadeau id
            if(file != null)
            {
                string adresseEasyGift = Directory.GetCurrentDirectory();
                using var image = Image.Load(file.OpenReadStream());
                image.Mutate(x => x.Resize(256, 256));   // Il faut changer le nom de la photo
                image.Save(adresseEasyGift+"/wwwroot/images/"+titre+".jpg");
                return true;
            }

            return false;
            
            
            
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
