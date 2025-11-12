using Microsoft.AspNetCore.Mvc;
using OSTA.BLL.DTOs.CategoryDTOS;
using OSTA.BLL.Interfaces;

namespace OSTA.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Category Controller Is Working");
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategory category)
        {
            var result = await categoryService.AddCategory(category);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await categoryService.GetAllCategories();
            return Ok(result);
        }
        [HttpGet("GetByName/{Name:alpha}")]
        public async Task<IActionResult> GetByName(string Name)
        {
            var result = await categoryService.GetByName(Name);
            return Ok(result);
        }

        [HttpDelete("Delete/{Name:alpha}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] string Name)
        {
            var result = await categoryService.Delete(Name);
            return Ok(result);
        }


        [HttpPut("Edit/{oldName:alpha}")]
        public async Task<IActionResult> EditCategory([FromRoute] string oldName, [FromBody] EditCategory dto)
        {
            var result = await categoryService.Update(oldName, dto);
            return Ok(result);
        }

    }
}
