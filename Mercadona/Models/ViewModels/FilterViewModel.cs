using Mercadona_V1.Models.Domain;

namespace Mercadona_V4.Models.ViewModels
{
    public class FilterViewModel
    {
        public IEnumerable<Produit> Produits { get; set; }
        public IEnumerable<Categorie> Categories { get; set; }
    }
}
