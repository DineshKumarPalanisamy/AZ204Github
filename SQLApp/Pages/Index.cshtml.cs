using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLApp.Models;
using SQLApp.Services;

namespace SQLApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ProductService _productService;

        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Products = new();
        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}