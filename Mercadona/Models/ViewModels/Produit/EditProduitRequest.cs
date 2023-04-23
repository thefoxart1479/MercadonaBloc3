using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mercadona_V1.Models.ViewModels.Produit
{
    public class EditProduitRequest
    {
        public Guid produitID { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public float prix { get; set; }
        public bool enPromotion { get; set; }
        public string imageURL { get; set; }

        public IEnumerable<SelectListItem> categories { get; set; }
        public string[] SelectedCategorie { get; set; } = Array.Empty<string>();

        public IEnumerable<SelectListItem> promotions { get; set; }
        public string[] SelectedPromotion { get; set; } = Array.Empty<string>();
    }
}
