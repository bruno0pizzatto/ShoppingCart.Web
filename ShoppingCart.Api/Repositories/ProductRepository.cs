using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Data;
using ShoppingCart.Api.Entities;
using ShoppingCart.Api.Repositories.Contracts;
using System.Runtime.InteropServices;

namespace ShoppingCart.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;

        public ProductRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            this.shoppingCartDbContext = shoppingCartDbContext;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await this.shoppingCartDbContext.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await shoppingCartDbContext.ProductCategories.SingleOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await shoppingCartDbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.shoppingCartDbContext.Products.ToListAsync();
            return products;
        }
    }
}
