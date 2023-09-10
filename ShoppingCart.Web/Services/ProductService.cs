using ShoppingCart.Models.Dtos;
using ShoppingCart.Web.Services.Contratcs;
using System.Net.Http.Json;

namespace ShoppingCart.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            try
            {
                var products = await this.httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
