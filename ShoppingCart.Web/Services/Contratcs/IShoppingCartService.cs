using ShoppingCart.Models.DTOs;

namespace ShoppingCart.Web.Services.Contratcs
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<CartItemDto>> GetItems(int userId);
        Task<CartItemDto> AddItem(CartItemToAddDto cartItemToAddDto);
    }
}
