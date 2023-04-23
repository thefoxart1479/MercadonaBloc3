using Mercadona_V1.Models.Domain;

namespace Mercadona_V1.Repositories
{
    public interface ICategorieRepository
    {

        Task<IEnumerable<Categorie>> GetAllAsync();
        Task<Categorie?> GetAsync(Guid id);
        Task<Categorie?> AddAsync(Categorie categorie);
        Task<Categorie?> UpdateAsync(Categorie categorie);
        Task<Categorie?> DeleteAsync(Guid id);

    }
}
