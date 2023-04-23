using Mercadona_V1.Models.Domain;

namespace Mercadona_V1.Repositories
{
    public interface IProduitRepository
    {

        Task<IEnumerable<Produit>> GetAllAsync();
        Task<Produit?> GetAsync(Guid id);
        Task<Produit> AddAsync(Produit produit);
        Task<Produit?> UpdateAsync(Produit produit);
        Task<Produit?> DeleteAsync(Guid id);

    }
}
