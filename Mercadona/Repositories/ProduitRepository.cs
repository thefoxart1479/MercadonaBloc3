using Mercadona_V1.Data;
using Mercadona_V1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mercadona_V1.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly MercadonaDbContext _dbContext;
        public ProduitRepository(MercadonaDbContext dbContext) 
        { 
            this._dbContext = dbContext;
        }

        public async Task<Produit> AddAsync(Produit produit)
        {
            await _dbContext.AddAsync(produit);
            await _dbContext.SaveChangesAsync();
            return produit;
        }

        public async Task<Produit?> DeleteAsync(Guid id)
        {
            var existingProduit = await _dbContext.Produits.FindAsync(id);

            if (existingProduit != null)
            {
                _dbContext.Produits.Remove(existingProduit);
                await _dbContext.SaveChangesAsync();
                return existingProduit;
            }

            return null;
        }

        public async Task<IEnumerable<Produit>> GetAllAsync()
        {
            return await _dbContext.Produits
                .Include(x => x.Categories)
                .Include(y => y.Promotions)
                .ToListAsync();
        }

        public async Task<Produit?> GetAsync(Guid Id)
        {
            return await _dbContext.Produits
                .Include (x => x.Categories)
                .Include (y => y.Promotions)
                .FirstOrDefaultAsync(x => x.produitID == Id);
        }

        public async Task<Produit?> UpdateAsync(Produit produit)
        {
            var existingProduit = await _dbContext.Produits
                .Include(x => x.Categories)
                .Include(y => y.Promotions)
                .FirstOrDefaultAsync(x => x.produitID == produit.produitID);

            if (existingProduit != null) 
            { 
                existingProduit.produitID = produit.produitID;
                existingProduit.libelle = produit.libelle;
                existingProduit.description = produit.description;
                existingProduit.prix = produit.prix;
                existingProduit.enPromotion = produit.enPromotion;
                existingProduit.Categories = produit.Categories;
                existingProduit.Promotions = produit.Promotions;
                existingProduit.imageURL = produit.imageURL;

                await _dbContext.SaveChangesAsync();
                return existingProduit;
            }

            return null;
        }
    }
}
