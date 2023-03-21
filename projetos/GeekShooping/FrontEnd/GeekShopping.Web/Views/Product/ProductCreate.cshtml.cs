using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GeekShopping.Web.Views.Product
{
    public class ProductCreate : PageModel
    {
        private readonly ILogger<ProductCreate> _logger;

        public ProductCreate(ILogger<ProductCreate> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}