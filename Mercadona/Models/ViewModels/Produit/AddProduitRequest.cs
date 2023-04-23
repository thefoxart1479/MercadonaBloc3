using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mercadona_V1.Models.ViewModels.Produit
{
    public class AddProduitRequest
    {
        public Guid produitID { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public float prix { get; set; }
        public bool enPromotion { get; set; }
        public string imageURL { get; set; }

        // Afficher les catégories
        public IEnumerable<SelectListItem> categories { get; set; }
        // Récuperer les catégories
        public string[] SelectedCategorie { get; set; } = Array.Empty<string>();

        // Afficher les catégories
        public IEnumerable<SelectListItem> promotions { get; set; }
        // Récuperer les catégories
        public string[] SelectedPromotion { get; set; } = Array.Empty<string>();

    }
}
