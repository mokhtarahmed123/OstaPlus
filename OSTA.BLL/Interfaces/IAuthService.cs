using OSTA.BLL.DTOs.AuthDTOs;

namespace OSTA.BLL.Interfaces
{
    public interface IAuthService
    {

        public Task<string> SignUp(SignUpUser signUpUser);
        public Task<string> Login(LoginUser loginUser);
        public Task<GetUser> GetByEmail(string email);
        public Task<List<GetAllUsersDTO>> GetAllUsersAsync();
        public Task<List<GetAllUsersDTO>> GetAllUsersByRoleNameAsync(string RoleName);
        public Task<int> CountOfUsers();
        public Task<int> CountOfUsersByRoleName(string RoleName);
        public Task<string> EditAsync(string Email, UpdateUserDTO user);
        public Task<string> Delete(string email);
        public Task<bool> ChangePasswordAsync(string email, string newPassword);
        public Task<bool> VerifyEmailAsync(string email, string token);
        public Task<string> RefreshTokenAsync(string refreshToken);
        public Task<string> LogoutAsync(string email);

    }
}
