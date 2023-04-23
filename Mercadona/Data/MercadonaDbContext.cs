using Mercadona_V1.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mercadona_V1.Data
{
    public class MercadonaDbContext : DbContext
    {
        public MercadonaDbContext(DbContextOptions<MercadonaDbContext> options) : base(options)
        {
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
    }
}
