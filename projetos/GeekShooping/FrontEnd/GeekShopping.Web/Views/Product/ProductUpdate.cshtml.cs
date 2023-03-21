using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GeekShopping.Web.Views.Product
{
    public class ProductUpdate : PageModel
    {
        private readonly ILogger<ProductUpdate> _logger;

        public ProductUpdate(ILogger<ProductUpdate> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}