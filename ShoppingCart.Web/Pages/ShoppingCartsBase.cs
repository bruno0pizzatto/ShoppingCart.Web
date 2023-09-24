using Microsoft.AspNetCore.Components;
using ShoppingCart.Models.DTOs;
using ShoppingCart.Web.Services.Contratcs;

namespace ShoppingCart.Web.Pages
{
    public class ShoppingCartsBase : ComponentBase
    {
        [Inject]
        public IShoppingCartService ShoppingCartService { get; set; }

        public IEnumerable<CartItemDto> ShoppingCartItems { get;set; }
        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                ShoppingCartItems = await ShoppingCartService.GetItems(HardCoded.UserId);
            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
            }
        }
    }
}
