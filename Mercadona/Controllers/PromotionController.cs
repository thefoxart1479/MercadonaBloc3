using Mercadona_V1.Data;
using Mercadona_V1.Models.Domain;
using Mercadona_V1.Models.ViewModels.Promotion;
using Mercadona_V1.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mercadona_V1.Controllers
{
    public class PromotionController : Controller
    {
        private readonly IPromotionRepository _dbcontext;
        public PromotionController(IPromotionRepository promotionRepository)
        {
            this._dbcontext = promotionRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> SubmitPromotion(AddPromotionRequest addPromotionRequest)
        {
            var promotion = new Promotion
            {
                dateDebut = addPromotionRequest.dateDebut,
                dateFin = addPromotionRequest.dateFin,
                remise = addPromotionRequest.remise,
            };

            await _dbcontext.AddAsync(promotion);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var promotions = await _dbcontext.GetAllAsync();

            return View(promotions);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var promotion = await _dbcontext.GetAsync(Id);

            if (promotion != null)
            {
                var editPromotionRequest = new EditPromotionRequest
                {
                    promotionID = promotion.promotionID,
                    dateDebut = promotion.dateDebut,
                    dateFin = promotion.dateFin,
                    remise = promotion.remise,
                };

                return View(editPromotionRequest);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPromotionRequest editPromotionRequest)
        {
            var promotion = new Promotion
            {
                promotionID = editPromotionRequest.promotionID,
                dateDebut = editPromotionRequest.dateDebut,
                dateFin = editPromotionRequest.dateFin,
                remise = editPromotionRequest.remise,
            };

            var updatePromotion = await _dbcontext.UpdateAsync(promotion);

            return RedirectToAction("Edit", new { Id = editPromotionRequest.promotionID });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditPromotionRequest editPromotionRequest)
        {
            var deletedPromotion = await _dbcontext.DeleteAsync(editPromotionRequest.promotionID);

            if (deletedPromotion != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { Id = editPromotionRequest.promotionID });
        }
    }
}
