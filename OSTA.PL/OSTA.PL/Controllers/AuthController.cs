using Microsoft.AspNetCore.Mvc;
using OSTA.BLL.DTOs.AuthDTOs;
using OSTA.BLL.Interfaces;

namespace OSTA.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Auth Controller Is Working");
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Result = await authService.GetAllUsersAsync();
            return Ok(new { Result, CountOfUsers = await authService.CountOfUsers() });
        }
        [HttpGet("GetAllUsersByRoleNameAsync/{Name}")]
        public async Task<IActionResult> GetAllUsersByRoleNameAsync(string Name)
        {
            var Result = await authService.GetAllUsersByRoleNameAsync(Name);
            return Ok(new { Result, CountOfUsers = await authService.CountOfUsersByRoleName(Name) });
        }

        [HttpGet("GetByEmail/{Email}")]
        public async Task<IActionResult> GetByEmail(string Email)
        {
            var Result = await authService.GetByEmail(Email);
            return Ok(Result);
        }

        [HttpPost("SignUp")]  // For All 
        public async Task<IActionResult> SignUp(SignUpUser signUp)
        {
            var Result = await authService.SignUp(signUp);
            return Ok(Result);
        }
        [HttpDelete("Delete/{email}")] // From Admin
        public async Task<IActionResult> Delete(string email)
        {
            var Result = await authService.Delete(email);
            return Ok(Result);
        }


        [HttpPut("Edit/{Email}")]
        public async Task<IActionResult> Edit(string Email, UpdateUserDTO user)
        {
            var Result = await authService.EditAsync(Email, user);
            return Ok(Result);
        }
    }
}
