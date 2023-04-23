namespace Mercadona_V1.Models.Domain
{
    public class Produit
    {

        public Guid produitID { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public float prix { get; set; }
        public bool enPromotion { get; set; }
        public string imageURL { get; set; }

        // Navigation property
        public ICollection<Categorie> Categories { get; set; } 
        public ICollection<Promotion> Promotions { get; set; } 

    }
}
