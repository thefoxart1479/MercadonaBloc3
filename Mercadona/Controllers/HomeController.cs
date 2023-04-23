using Mercadona_V1.Models;
using Mercadona_V1.Models.Domain;
using Mercadona_V1.Models.ViewModels.Produit;
using Mercadona_V1.Repositories;
using Mercadona_V3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Mercadona_V1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduitRepository produitRepository;
        private readonly ICategorieRepository categorieRepository;
        private readonly IPromotionRepository promotionRepository;

        public HomeController(ILogger<HomeController> logger, IProduitRepository produitRepository, ICategorieRepository categorieRepository, IPromotionRepository promotionRepository)
        {
            _logger = logger;
            this.produitRepository = produitRepository;
            this.categorieRepository = categorieRepository;
            this.promotionRepository = promotionRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await produitRepository.GetAllAsync();

            var categories = await categorieRepository.GetAllAsync();

            var model = new HomeViewModel
            {
                Produits = produits,
                Categories = categories
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<IActionResult> EditPromotion(Guid produitID, string[] SelectedPromotion)
        {
            var produit = await produitRepository.GetAsync(produitID);

            if(SelectedPromotion.Length > 0)
            {
                var promotions = await promotionRepository.GetAsync(Guid.Parse(SelectedPromotion[0]));
                produit.Promotions.Clear();
                produit.enPromotion = true;
                produit.Promotions.Add(promotions);
            }
            else
            {
                produit.enPromotion =false;
                produit.Promotions.Clear();
            }

            await produitRepository.UpdateAsync(produit);

            return RedirectToAction("Index");
        }


    }
}