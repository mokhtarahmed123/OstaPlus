using OSTA.DAL.Entities;

namespace OSTA.DAL.Interfaces
{
    public interface IAuthRepository
    {
        public Task<List<ApplicationUser>> GetAll();
        public Task<List<ApplicationUser>> GetAllByRoleName(string roleName);
        public Task<ApplicationUser> GetByEmail(string email);
        public Task<int> GetCountByRoleName(string roleName);
        public Task<int> GetCountOfAll();
        public Task<bool> UserWithEmailIsFound(string email);
        public Task<bool> CheckIfUserWantChangeEmailNotRepeated(string Email, string id);

    }
}
