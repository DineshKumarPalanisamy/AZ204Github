using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLApp.Models;
using SQLApp.Services;

namespace SQLApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products = new List<Product>();
        public void OnGet()
        {
            ProductService productsService = new ProductService();

            Products = productsService.GetProducts();
        }
    }
}