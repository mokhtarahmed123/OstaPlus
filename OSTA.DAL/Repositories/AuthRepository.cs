using Microsoft.EntityFrameworkCore;
using OSTA.DAL.Context;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.DAL.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DbSet<ApplicationUser> _ApplicationUserRepository;

        public AuthRepository(OstaContext dbContext)
        {
            _ApplicationUserRepository = dbContext.Set<ApplicationUser>();
        }

        public async Task<bool> CheckIfUserWantChangeEmailNotRepeated(string Email, string id)
        {
            return await _ApplicationUserRepository.AnyAsync(a => a.Email == Email && a.Id != id);
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _ApplicationUserRepository.Include(A => A.RoleApplication).ToListAsync();
        }

        public async Task<List<ApplicationUser>> GetAllByRoleName(string roleName)
        {
            return await _ApplicationUserRepository.Where(a => a.RoleApplication.Name == roleName).ToListAsync();

        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            return await _ApplicationUserRepository.Where(a => a.Email == email).Include(A => A.RoleApplication).FirstOrDefaultAsync();
        }

        public async Task<int> GetCountByRoleName(string roleName)
        {
            return await _ApplicationUserRepository.Where(a => a.RoleApplication.Name == roleName).Include(A => A.RoleApplication).CountAsync();
        }

        public async Task<int> GetCountOfAll()
        {
            var Result = await _ApplicationUserRepository.CountAsync();
            return Result;
        }

        public async Task<bool> UserWithEmailIsFound(string email)
        {
            return await _ApplicationUserRepository.AnyAsync(x => x.Email == email);
        }
    }
}
