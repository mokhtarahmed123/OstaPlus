using Microsoft.EntityFrameworkCore;
using OSTA.DAL.Context;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DbSet<RoleApplication> _RoleRepository;


        public RoleRepository(OstaContext dbContext)
        {
            _RoleRepository = dbContext.Set<RoleApplication>();

        }

        public async Task<string> GetIdByName(string Name)
        {
            var Role = await _RoleRepository.AsNoTracking().FirstOrDefaultAsync(a => a.Name.ToLower() == Name.ToLower());
            return Role.Id.ToString();
        }

        public Task<bool> NameISFoundWithAnotherId(string Name, string id)
        {
            return _RoleRepository.AsNoTracking().AnyAsync(r => r.Name.ToLower() == Name.ToLower() && r.Id.ToString() != id.ToString());
        }

        public Task<RoleApplication> GetByName(string Name)
        {
            return _RoleRepository.AsNoTracking().FirstOrDefaultAsync(r => r.Name.ToLower() == Name.ToLower());
        }

        public Task<bool> RoleNameIsFound(string Name)
        {
            return _RoleRepository.AsNoTracking().AnyAsync(a => a.Name.ToLower() == Name.ToLower());

        }

        public async Task<List<RoleApplication>> GetAll()
        {
            return await _RoleRepository.ToListAsync();
        }
    }
}
