namespace Mercadona_V1.Models.ViewModels.Promotion
{
    public class EditPromotionRequest
    {
        public Guid promotionID { get; set; }
        public string dateDebut { get; set; }
        public string dateFin { get; set; }
        public int remise { get; set; }
    }
}
