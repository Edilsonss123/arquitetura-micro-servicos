using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GeekShopping.Web.Views.Product
{
    public class ProductDelete : PageModel
    {
        private readonly ILogger<ProductDelete> _logger;

        public ProductDelete(ILogger<ProductDelete> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}