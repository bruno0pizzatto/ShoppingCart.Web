using ShoppingCart.Api.Entities;
using ShoppingCart.Api.Repositories.Contracts;
using ShoppingCart.Models.Dtos;
using ShoppingCart.Models.DTOs;

namespace ShoppingCart.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        public Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
