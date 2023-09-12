using ShoppingCart.Api.Entities;
using ShoppingCart.Models.Dtos;
using ShoppingCart.Models.DTOs;

namespace ShoppingCart.Api.Repositories.Contracts
{
    public interface IShoppingCartRepository
    {
        Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto);
        Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto);
        Task DeleteItem(int id);
        Task<CartItem> GetItem(int id);
        Task<IEnumerable<CartItem>> GetItems(int userId);

    }
}
