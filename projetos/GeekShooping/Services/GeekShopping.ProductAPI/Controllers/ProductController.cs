using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepositoy;

        public ProductController(IProductRepository repository)
        {
            _productRepositoy = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        //[Authorize]
        public  async Task<ActionResult<IEnumerable<ProductVO>>> FindByAll()
        {
            var products = await _productRepositoy.FindAll();
            return Ok(products);
        }

        [HttpGet("{id:long}")]
        //[Authorize]
        public  async Task<ActionResult> FindById(long id)
        {
            var product = await _productRepositoy.FindById(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        //[Authorize]
        public  async Task<ActionResult> Create([FromBody] ProductVO productVO)
        {
            if(productVO == null) return BadRequest();
            var product = await _productRepositoy.Create(productVO);
            return Ok(product);
        }

        [HttpPut]
        //[Authorize]
        public  async Task<ActionResult> Update([FromBody] ProductVO productVO)
        {
            if(productVO == null) return BadRequest();
            var product = await _productRepositoy.Update(productVO);
            return Ok(product);
        }

        
        [HttpDelete("{id:long}")]
        //[Authorize(Roles = RoleIdentity.Admin)]
        public  async Task<ActionResult> Delete(long id)
        {
            var status = await _productRepositoy.Delete(id);
            if(!status) return BadRequest();
            return Ok(status);
        }
    }
}