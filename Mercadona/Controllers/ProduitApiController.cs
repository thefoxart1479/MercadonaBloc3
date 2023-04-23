using Mercadona_V1.Models.Domain;
using Mercadona_V1.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mercadona.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProduitApiController : Controller
    {
        private readonly ICategorieRepository categorieRepository;
        private readonly IPromotionRepository promotionRepository;
        private readonly IProduitRepository produitRepository;

        public ProduitApiController(ICategorieRepository categorieRepository, IProduitRepository produitRepository, IPromotionRepository promotionRepository)
        {
            this.categorieRepository = categorieRepository;
            this.produitRepository = produitRepository;
            this.promotionRepository = promotionRepository;

        }

        [HttpGet]
        [Route("getPromotion")]
        public async Task<IEnumerable<Promotion>> GetPromotion()
        {
            var promotions = await promotionRepository.GetAllAsync();

            return promotions;
        }

        [HttpGet]
        [Route("getProduit")]
        public ActionResult<IEnumerable<Produit>> GetProduits()
        {
            var produits = produitRepository.GetAllAsync().Result;

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                MaxDepth = 32
            };

            var produitsArray = produits.ToArray();

            return new JsonResult(produitsArray, options);
        }


        [HttpGet]
        [Route("getProduit/{id}")]
        public ActionResult<IEnumerable<Produit>> GetProduitsById(Guid id)
        {
            var produit = produitRepository.GetAsync(id);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                MaxDepth = 32
            };

            var produitArray = produit.Result;

            return new JsonResult(produitArray, options);
        }

    }
}
