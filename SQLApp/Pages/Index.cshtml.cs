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
        public bool IsBeta;

        public void OnGet()
        {
            IsBeta = _productService.IsBeta().Result;
            Products = _productService.GetProducts();
        }
    }
}