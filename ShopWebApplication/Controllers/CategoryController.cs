using Core.Dtos.CategoryDtos;
using Core.Dtos.ProductDtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoreService categoreService;

        public CategoryController(ICategoreService categoreService)
        {
            this.categoreService = categoreService;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await categoreService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await categoreService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto model)
        {
            await categoreService.Create(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditCategorytDto model)
        {
            await categoreService.Edit(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await categoreService.Delete(id);
            return Ok();
        }
    }
}
