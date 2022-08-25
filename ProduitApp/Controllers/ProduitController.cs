using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProduitApp.Models;
using ProduitApp.Service;

namespace ProduitApp.Controllers
{
    /*3. Ajoutez un contrôleur ProduitController dans le dossier Controllers du projet. Vous
    pouvez utiliser le modèle Contrôleur MVC avec des actions de lecture/écriture.*/
    public class ProduitController : Controller
    {
        private readonly IProduitService _produitService;
        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }

        // GET: ProduitController
        public ActionResult Index()
        {
            return View(_produitService.AllProducts());
        }

        // GET: ProduitController/Details/5
        public ActionResult Details(int id)
        {
            Produit currentProduit = _produitService.GetProductById(id);
            return View(currentProduit);
        }

        // GET: ProduitController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProduitController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProduitController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProduitController/Delete/5
        public ActionResult Delete(int id)
        {
            Produit ProductToDelete = _produitService.GetProductById(id);
            return View(ProductToDelete);
        }

        // POST: ProduitController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _produitService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
