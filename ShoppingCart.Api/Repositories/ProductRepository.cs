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

        public Task<ProductCategory> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await this.shoppingCartDbContext.Products.ToListAsync();
            return products;
        }
    }
}
