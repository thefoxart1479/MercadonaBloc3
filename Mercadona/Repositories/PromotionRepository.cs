using Mercadona_V1.Data;
using Mercadona_V1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mercadona_V1.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly MercadonaDbContext _dbcontext;
        public PromotionRepository(MercadonaDbContext mercadonnaDbContext)
        {
            this._dbcontext = mercadonnaDbContext;
        }

        public async Task<Promotion?> AddAsync(Promotion promotion)
        {
            await _dbcontext.Promotions.AddAsync(promotion);
            await _dbcontext.SaveChangesAsync();
            return promotion;
        }

        public async Task<Promotion?> DeleteAsync(Guid id)
        {
            var existingPromotion = await _dbcontext.Promotions.FindAsync(id);

            if (existingPromotion != null)
            {
                _dbcontext.Promotions.Remove(existingPromotion);
                await _dbcontext.SaveChangesAsync();
                return existingPromotion;
            }

            return null;
        }

        public async Task<IEnumerable<Promotion>> GetAllAsync()
        {
            return await _dbcontext.Promotions.ToListAsync();
        }

        public Task<Promotion?> GetAsync(Guid id)
        {
            return _dbcontext.Promotions.FirstOrDefaultAsync(x => x.promotionID == id);
        }

        public async Task<Promotion?> UpdateAsync(Promotion promotion)
        {
            var existingPromotion = await _dbcontext.Promotions.FindAsync(promotion.promotionID);

            if (existingPromotion != null)
            {
                existingPromotion.dateDebut = promotion.dateDebut;
                existingPromotion.dateFin = promotion.dateFin;
                existingPromotion.remise = promotion.remise;

                await _dbcontext.SaveChangesAsync();

                return existingPromotion;
            }

            return null;
        }
    }
}
