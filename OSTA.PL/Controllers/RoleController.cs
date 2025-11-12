using Microsoft.AspNetCore.Mvc;
using OSTA.BLL.DTOs.RoleDTOs;
using OSTA.BLL.Interfaces;

namespace OSTA.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices roleServices;

        public RoleController(IRoleServices roleServices)
        {
            this.roleServices = roleServices;
        }
        [HttpGet("Index")]

        public IActionResult Index()
        {
            return Ok("Role Controller Is Working");
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateRoleDto createRole)
        {
            var Result = await roleServices.CreateRoleAsync(createRole);
            return Ok(Result);

        }

        [HttpDelete("Delete/{Name:alpha}")]
        public async Task<IActionResult> Delete([FromRoute] string Name)
        {
            var Result = await roleServices.DeleteRoleAsync(Name);
            return Ok(Result);

        }
        [HttpPut("Edit/{Name:alpha}")]
        public async Task<IActionResult> Edit(string Name, [FromBody] EditRoleDto editRole)
        {
            var Result = await roleServices.UpdateRoleAsync(Name, editRole);
            return Ok(Result);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = await roleServices.GetAllRolesAsync();
            return Ok(Result);
        }


    }
}
