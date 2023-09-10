using ShoppingCart.Models.Dtos;

namespace ShoppingCart.Web.Services.Contratcs
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
    }
}
