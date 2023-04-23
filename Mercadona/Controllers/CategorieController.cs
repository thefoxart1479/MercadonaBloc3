using Mercadona_V1.Data;
using Mercadona_V1.Models.Domain;
using Mercadona_V1.Models.ViewModels.Categorie;
using Mercadona_V1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mercadona_V1.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorieRepository _dbcontext;
        public CategorieController(ICategorieRepository categorieRepository)
        {
            this._dbcontext = categorieRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> SubmitCategorie(AddCategorieRequest addCategorieRequest) 
        {
            var categorie = new Categorie
            {
                libelle = addCategorieRequest.Libelle,
            };

            await _dbcontext.AddAsync(categorie);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var categories = await _dbcontext.GetAllAsync();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id) 
        {
            var categorie = await _dbcontext.GetAsync(Id);

            if(categorie != null) 
            {
                var editCategorieRequest = new EditCategorieRequest
                {
                    categorieID = categorie.categorieID,
                    libelle = categorie.libelle,
                };

                return View(editCategorieRequest);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategorieRequest editCategorieRequest) 
        {
            var categorie = new Categorie
            {
                categorieID = editCategorieRequest.categorieID,
                libelle = editCategorieRequest.libelle,
            };

            var updatdeCategorie = await _dbcontext.UpdateAsync(categorie);

            return RedirectToAction("Edit", new { Id = editCategorieRequest.categorieID });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditCategorieRequest editCategorieRequest) 
        {
            var deletedCategorie = await _dbcontext.DeleteAsync(editCategorieRequest.categorieID);

            if (deletedCategorie != null) 
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { Id = editCategorieRequest.categorieID});
        }
    }
}
