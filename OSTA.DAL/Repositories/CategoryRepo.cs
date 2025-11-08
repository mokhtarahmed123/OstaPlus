using CBS.Infrastructure.Bases;
using Microsoft.EntityFrameworkCore;
using OSTA.DAL.Context;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.DAL.Repositories
{
    public class CategoryRepo : GenericRepositoryAsync<Category>, ICategoryRepo
    {

        private readonly DbSet<Category> _CategoryRepository;

        public CategoryRepo(OstaContext dbContext) : base(dbContext)
        {
            _CategoryRepository = dbContext.Set<Category>();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _CategoryRepository.ToListAsync();
        }

        public async Task<Category?> GetByName(string Name)
        {
            return await _CategoryRepository.AsNoTracking().FirstOrDefaultAsync(c => c.Name.ToLower() == Name.ToLower());
        }

        public async Task<string> GetIdByName(string Name)
        {
            var Result = await _CategoryRepository.AsNoTracking().FirstOrDefaultAsync(c => c.Name.ToLower() == Name.ToLower());
            return Result.Id.ToString();
        }

        public Task<bool> NameISFoundWithAnotherId(string Name, string Id)
        {
            return _CategoryRepository.AsNoTracking().AnyAsync(c => c.Name == Name && c.Id != Id);
        }
    }
}
