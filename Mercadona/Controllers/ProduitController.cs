using Mercadona_V1.Models.Domain;
using Mercadona_V1.Models.ViewModels.Categorie;
using Mercadona_V1.Models.ViewModels.Produit;
using Mercadona_V1.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mercadona_V1.Controllers
{
    public class ProduitController : Controller
    {
        private readonly ICategorieRepository categorieRepository;
        private readonly IPromotionRepository promotionRepository;
        private readonly IProduitRepository produitRepository;

        public ProduitController(ICategorieRepository categorieRepository, IProduitRepository produitRepository, IPromotionRepository promotionRepository)
        {
            this.categorieRepository = categorieRepository;
            this.produitRepository = produitRepository;
            this.promotionRepository = promotionRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categorieRepository.GetAllAsync();
            var promotions = await promotionRepository.GetAllAsync();

            var model = new AddProduitRequest
            {
                categories = categories.Select(x => new SelectListItem 
                { 
                    Text = x.libelle, Value = x.categorieID.ToString() 
                }),

                promotions = promotions.Select(x => new SelectListItem 
                { 
                    Text = "Du "+x.dateDebut+" au "+x.dateFin+" : "+x.remise.ToString(), Value = x.promotionID.ToString() 
                }),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProduitRequest addProduit)
        {
            var produit = new Produit
            {
                libelle = addProduit.libelle,
                description = addProduit.description,
                prix = addProduit.prix,
                imageURL = addProduit.imageURL,
            };

            var selectedCategories = new List<Categorie>();
            foreach(var selectedCategorieId in addProduit.SelectedCategorie)
            {
                var selectedCategorieIdAsGuid = Guid.Parse(selectedCategorieId);
                var existingCategorie = await categorieRepository.GetAsync(selectedCategorieIdAsGuid);

                if (existingCategorie != null) 
                {
                    selectedCategories.Add(existingCategorie);
                }
            }

            var selectedPromotions = new List<Promotion>();
            foreach (var selectedPromotionId in addProduit.SelectedPromotion) 
            {
                var selectedPromotionIdAsGuid = Guid.Parse(selectedPromotionId);
                var existingPromotion = await promotionRepository.GetAsync(selectedPromotionIdAsGuid);

                if (existingPromotion != null) 
                { 
                    selectedPromotions.Add(existingPromotion);
                    produit.enPromotion = true;
                }
            }

            produit.Categories = selectedCategories;
            produit.Promotions = selectedPromotions;

            await produitRepository.AddAsync(produit);

            return RedirectToAction("Add");
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var produits = await produitRepository.GetAllAsync();

            return View(produits);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var produit = await produitRepository.GetAsync(Id);
            var categoriesDomainModel = await categorieRepository.GetAllAsync();
            var promotionDomainModel = await promotionRepository.GetAllAsync();

            if(produit != null) 
            {
                var model = new EditProduitRequest
                {
                    produitID = produit.produitID,
                    libelle = produit.libelle,
                    description = produit.description,
                    prix = produit.prix,
                    enPromotion = produit.enPromotion,
                    imageURL = produit.imageURL,

                    categories = categoriesDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.libelle,
                        Value = x.categorieID.ToString()
                    }),
                    SelectedCategorie = produit.Categories.Select(x => x.categorieID.ToString()).ToArray(),

                    promotions = promotionDomainModel.Select(x => new SelectListItem
                    {
                        Text = "Du " + x.dateDebut + " au " + x.dateFin + " : " + x.remise.ToString(),
                        Value = x.promotionID.ToString()
                    }),
                    SelectedPromotion = produit.Promotions.Select(x => x.promotionID.ToString()).ToArray()
                };

                return View(model);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProduitRequest editProduit)
        {
            var produitDomainModel = new Produit
            {
                produitID = editProduit.produitID,
                libelle = editProduit.libelle,
                description = editProduit.description,
                prix = editProduit.prix,
                imageURL = editProduit.imageURL,
            };

            var selectedCategorie = new List<Categorie>();
            foreach(var selectedCategorieId in editProduit.SelectedCategorie)
            {
                if(Guid.TryParse(selectedCategorieId, out var categorie))
                {
                    var foundCategorie = await categorieRepository.GetAsync(categorie);

                    if(foundCategorie != null) 
                    { 
                        selectedCategorie.Add(foundCategorie);
                    }
                }
            }

            produitDomainModel.Categories = selectedCategorie;

            var selectedPromotion = new List<Promotion>();
            foreach(var selectedPromotionId in  editProduit.SelectedPromotion)
            {
                if (Guid.TryParse(selectedPromotionId, out var promotion))
                {
                    var foundPromotion = await promotionRepository.GetAsync(promotion);

                    if (foundPromotion != null)
                    {
                        selectedPromotion.Add(foundPromotion);
                        produitDomainModel.enPromotion = true;
                    }
                }
            }

            produitDomainModel.Promotions = selectedPromotion;

            var updatedProduit = await produitRepository.UpdateAsync(produitDomainModel);

            return RedirectToAction("Edit");


        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditProduitRequest editProduit)
        {
            var deletedProduit = await produitRepository.DeleteAsync(editProduit.produitID);

            return RedirectToAction("List");
        }
    }

}
