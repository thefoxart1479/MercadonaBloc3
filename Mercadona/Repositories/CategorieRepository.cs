using Mercadona_V1.Data;
using Mercadona_V1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mercadona_V1.Repositories
{
    public class CategorieRepository : ICategorieRepository
    {
        private readonly MercadonaDbContext _dbcontext;
        public CategorieRepository(MercadonaDbContext mercadonnaDbContext)
        {
            this._dbcontext = mercadonnaDbContext;
        }

        public async Task<Categorie?> AddAsync(Categorie categorie)
        {
            await _dbcontext.Categories.AddAsync(categorie);
            await _dbcontext.SaveChangesAsync();
            return categorie;
        }

        public async Task<Categorie?> DeleteAsync(Guid id)
        {
            var existingCategorie = await _dbcontext.Categories.FindAsync(id);

            if (existingCategorie != null) 
            { 
                _dbcontext.Categories.Remove(existingCategorie);
                await _dbcontext.SaveChangesAsync();
                return existingCategorie;
            }

            return null;
        }

        public async Task<IEnumerable<Categorie>> GetAllAsync()
        {
            return await _dbcontext.Categories.ToListAsync();
        }

        public Task<Categorie?> GetAsync(Guid id)
        {
            return _dbcontext.Categories.FirstOrDefaultAsync(x => x.categorieID == id);
        }

        public async Task<Categorie?> UpdateAsync(Categorie categorie)
        {
            var existingCategorie = await _dbcontext.Categories.FindAsync(categorie.categorieID);

            if (existingCategorie != null) 
            { 
                existingCategorie.libelle = categorie.libelle;

                await _dbcontext.SaveChangesAsync();

                return existingCategorie;
            }

            return null;
        }
    }
}
