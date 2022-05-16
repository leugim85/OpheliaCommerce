using Microsoft.EntityFrameworkCore;
using OpheliaCommerce.Domain.Entities;

namespace OpheliaCommerce.Data.Context
{
    public class EcommerceContext: DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options): base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Shopping> Shoppings { get; set; }

        public DbSet<ShoppingDetails> ShoppingDetails { get; set; }
    }
}
