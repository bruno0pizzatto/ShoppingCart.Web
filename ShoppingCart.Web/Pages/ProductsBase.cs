using Microsoft.AspNetCore.Components;
using ShoppingCart.Models.Dtos;
using ShoppingCart.Web.Services.Contratcs;

namespace ShoppingCart.Web.Pages
{
    public class ProductsBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetItems();
        }
    }
}
