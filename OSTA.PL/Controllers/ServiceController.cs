using Microsoft.AspNetCore.Mvc;
using OSTA.BLL.DTOs.ServiceDTOs;
using OSTA.BLL.Interfaces;

namespace OSTA.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }


        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Service Controller Is Working");
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> ShowAll()
        {
            var services = await _serviceService.ShowAll();
            return Ok(services);
        }
        [HttpGet("category/{categoryName:alpha}")]
        public async Task<IActionResult> GetByCategory(string categoryName)
        {
            var services = await _serviceService.GetByCategory(categoryName);
            return Ok(services);
        }
        [HttpGet("Count")]
        public async Task<IActionResult> CountOfServices()
        {
            var count = await _serviceService.CountOfServices();
            return Ok(count);
        }
        [HttpGet("Filter")]
        public async Task<IActionResult> Filter([FromQuery] ServiceFilter serviceFilter)
        {
            var services = await _serviceService.Filter(serviceFilter);
            return Ok(services);
        }



        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddServiceDTO addService)
        {
            var result = await _serviceService.Add(addService);
            return Created("", result);
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UpdateServiceDTO updateService)
        {
            var result = await _serviceService.Update(id, updateService);
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _serviceService.Delete(id);
            return Ok(result);
        }
    }
}
