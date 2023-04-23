using Newtonsoft.Json;

namespace Mercadona_V1.Models.Domain
{
    public class Promotion
    {
        public Guid promotionID { get; set; }
        public string dateDebut { get; set; }
        public string dateFin { get; set; }
        public int remise { get; set; }

        [JsonIgnore]
        public ICollection<Produit> produits { get; set; }

    }
}
