using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GeekShopping.Web.Views.Product
{
    public class ProductIndex : PageModel
    {
        private readonly ILogger<ProductIndex> _logger;

        public ProductIndex(ILogger<ProductIndex> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}