using Microsoft.AspNetCore.Mvc;
using OSTA.BLL.DTOs.StoreDTOs;
using OSTA.BLL.Interfaces;

namespace OSTA.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService storeService;

        public StoreController(IStoreService storeService)
        {
            this.storeService = storeService;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Store Controller Is Working");
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddStore([FromBody] OSTA.BLL.DTOs.StoreDTOs.AddStoreDTO model)
        {
            var result = await storeService.AddStoreAsync(model);
            return Ok(result);
        }
        [HttpGet("Count")]
        public async Task<IActionResult> CountStores()
        {
            var result = await storeService.CountStoresAsync();
            return Ok(result);
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetStoreById([FromRoute] string id)
        {
            var result = await storeService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStores()
        {
            var result = await storeService.GetAllAsync();
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteStore([FromRoute] string id)
        {
            var result = await storeService.DeleteStoreAsync(id);
            return Ok(result);
        }
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditStore([FromRoute] string id, [FromBody] UpdateStoreDTO model)
        {
            var result = await storeService.UpdateStoreAsync(id, model);
            return Ok(result);


        }
        [HttpPost("Filter")]

        public async Task<IActionResult> FilterStores([FromQuery] StoreFilterDTO filter)
        {
            var result = await storeService.FilterAsync(filter);
            return Ok(result);
        }

    }
}
