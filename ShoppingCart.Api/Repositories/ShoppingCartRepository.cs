using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Data;
using ShoppingCart.Api.Entities;
using ShoppingCart.Api.Repositories.Contracts;
using ShoppingCart.Models.Dtos;
using ShoppingCart.Models.DTOs;

namespace ShoppingCart.Api.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;

        public ShoppingCartRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            this.shoppingCartDbContext = shoppingCartDbContext;
        }

        private async Task<bool> CartItemExists(int cartId, int productId)
        {
            return await this.shoppingCartDbContext.CartItems.AnyAsync(c => c.CartId == cartId 
                                                                         && c.ProductId == productId);
        }
        public async Task<CartItem> AddItem(CartItemToAddDto cartItemToAddDto)
        {
            if(await CartItemExists(cartItemToAddDto.CartId, cartItemToAddDto.ProductId) == false)
            {
                var item = await (from product in this.shoppingCartDbContext.Products
                                  where product.Id == cartItemToAddDto.ProductId
                                  select new CartItem
                                  {
                                      CartId = cartItemToAddDto.CartId,
                                      ProductId = product.Id,
                                      Qty = cartItemToAddDto.Qty
                                  }).SingleOrDefaultAsync();
                if (item != null)
                {
                    var result = await this.shoppingCartDbContext.CartItems.AddAsync(item);
                    await this.shoppingCartDbContext.SaveChangesAsync();
                    return result.Entity;
                }
            }
            
            return null;
        }

        public Task DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CartItem> GetItem(int id)
        {
            return await (from cart in this.shoppingCartDbContext.Carts
                          join cartItem in this.shoppingCartDbContext.CartItems
                          on cart.Id equals cartItem.CartId
                          where cartItem.Id == id
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId = cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetItems(int userId)
        {
            return await (from cart in this.shoppingCartDbContext.Carts
                          join cartItem in this.shoppingCartDbContext.CartItems
                          on cart.Id equals cartItem.Id
                          where cart.Id == userId
                          select new CartItem
                          {
                              Id = cartItem.Id,
                              ProductId= cartItem.ProductId,
                              Qty = cartItem.Qty,
                              CartId = cartItem.CartId
                          }).ToListAsync();
        }

        public Task<CartItem> UpdateQty(int id, CartItemQtyUpdateDto cartItemQtyUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
