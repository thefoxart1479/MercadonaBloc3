using Mercadona_V1.Models.Domain;
using Mercadona_V1.Models.ViewModels.Produit;

namespace Mercadona_V3.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Produit> Produits { get; set; }

        public IEnumerable<Categorie> Categories { get; set; }

        public EditProduitRequest EditProduitRequests { get; set; }
        public Guid produitID { get; set; }
        public string[] SelectedPromotion { get; set; } = Array.Empty<string>();

    }
}
