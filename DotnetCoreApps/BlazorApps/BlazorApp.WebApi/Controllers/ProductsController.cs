using BlazorApp.Shared;
using BlazorApp.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BlazorApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceComponent serviceComponent;

        public ProductsController(IServiceComponent component)
        {
            this.serviceComponent = component;
        }

        [HttpGet]
        public async Task<IActionResult> AllProducts()
        {
            var data = this.serviceComponent.GetProducts();
            return Ok(data);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> Product(string id)
        {
            var pId = int.Parse(id);
            var data = this.serviceComponent.GetProduct(pId);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product p)
        {
            this.serviceComponent.AddProduct(p);
            return Ok ();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product p)
        {
            this.serviceComponent.UpdateProduct(p);
            return  Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            this.serviceComponent.DeleteProduct(id);
            return Ok();    
        }
    }
}
