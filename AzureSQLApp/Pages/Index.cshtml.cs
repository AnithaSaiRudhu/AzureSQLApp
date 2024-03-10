using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AzureSQLApp.Models;
using AzureSQLApp.Services;

namespace AzureSQLApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;

        public void OnGet()
        {
            ProductServices productServices = new ProductServices();
            Products = productServices.GetProductfromSQL();

        }

    }
}