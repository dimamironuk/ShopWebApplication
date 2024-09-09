using Core.Dtos.CategoryDtos;
using Core.Dtos.ProductDtos;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await productService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto model)
        {
            await productService.Create(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditProductDto model)
        {
            await productService.Edit(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.Delete(id);
            return Ok();
        }
    }
}
