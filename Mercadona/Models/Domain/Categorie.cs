using Newtonsoft.Json;

namespace Mercadona_V1.Models.Domain
{
    public class Categorie
    {

        public Guid categorieID { get; set; }
        public string libelle { get; set; }


        [JsonIgnore]
        public ICollection<Produit> produits { get; set; }

    }
}
