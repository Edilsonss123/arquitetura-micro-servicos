using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GeekShopping.Web.Views.Shared
{
    public class _LoginPartial : PageModel
    {
        private readonly ILogger<_LoginPartial> _logger;

        public _LoginPartial(ILogger<_LoginPartial> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}