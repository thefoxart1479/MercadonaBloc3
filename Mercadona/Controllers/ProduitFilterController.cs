using Mercadona_V1.Models.Domain;
using Mercadona_V1.Repositories;
using Mercadona_V3.Models.ViewModels;
using Mercadona_V4.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Mercadona_V4.Controllers
{
    public class ProduitFilterController : Controller
    {
        private readonly IProduitRepository produitRepository;
        private readonly ICategorieRepository categorieRepository;

        public ProduitFilterController(IProduitRepository produitRepository, ICategorieRepository categorieRepository)
        {
            this.produitRepository = produitRepository;
            this.categorieRepository = categorieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List(Guid Id)
        {

            var selectedCategorie = await categorieRepository.GetAsync(Id);
            var produits = await produitRepository.GetAllAsync();
            var allCategories = await categorieRepository.GetAllAsync();

            if(selectedCategorie != null && produits != null) 
            {
                IEnumerable<Produit> filteredProduit = produits.Where(x => x.Categories.Contains(selectedCategorie));

                var model = new FilterViewModel
                {
                    Produits = filteredProduit,
                    Categories = allCategories
                };

                return View(model);
            }

            return RedirectToAction("Index", "Home");
            
        }
    }
}
