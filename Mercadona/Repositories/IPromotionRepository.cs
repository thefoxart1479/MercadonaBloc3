using Mercadona_V1.Models.Domain;

namespace Mercadona_V1.Repositories
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetAllAsync();
        Task<Promotion?> GetAsync(Guid id);
        Task<Promotion?> AddAsync(Promotion promotion);
        Task<Promotion?> UpdateAsync(Promotion promotion);
        Task<Promotion?> DeleteAsync(Guid id);

    }
}
