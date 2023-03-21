using System.Net;
using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeekShopping.Web.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        //[HttpGet("create")]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        
        //[Authorize]
        public async Task<IActionResult> ProductCreate(ProductModel productVO)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateProduct(productVO);
                if (product != null) return RedirectToAction(
                    nameof(ProductIndex)
                );
            }
            return View(productVO);
        }
        
        [HttpGet("update/{id:long}")]
        public async Task<IActionResult> ProductUpdate(long id)
        {
            var product = await _productService.FindProductById(id);
            if (product != null) return View(product);

            return NotFound();
        }
        
        [HttpPost("update")]
        //[Authorize]
        public async Task<IActionResult> ProductUpdate(ProductModel productVO)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.UpdateProduct(productVO);
                Console.WriteLine(product);
                if (product != null) return RedirectToAction(
                    nameof(ProductIndex)
                );
            }
            return View(productVO);
        }
        
        [HttpGet("delete/{id:long}")]
        //[Authorize]
        public async Task<IActionResult> ProductDelete(long id)
        {
            var product = await _productService.FindProductById(id);
            if (product != null) return View(product);

            return NotFound();
        }
        
        [HttpPost("delete")]
        //[Authorize(Roles = RoleIdentity.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel productVO)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductById(productVO.Id);
                if (response) return RedirectToAction(
                    nameof(ProductIndex)
                );
            }
            return View(productVO);
        }
    }
}