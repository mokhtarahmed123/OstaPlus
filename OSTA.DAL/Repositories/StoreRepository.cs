using CBS.Infrastructure.Bases;
using Microsoft.EntityFrameworkCore;
using OSTA.DAL.Context;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.DAL.Repositories
{
    public class StoreRepository : GenericRepositoryAsync<Store>, IStoreRepository
    {
        private readonly DbSet<Store> _StoreRepository;


        public StoreRepository(OstaContext dbContext) : base(dbContext)
        {
            _StoreRepository = dbContext.Set<Store>();
        }

        public async Task<int> CountAsync()
        {
            return await _StoreRepository.AsNoTracking().CountAsync();
        }

        public async Task<List<Store>> GetAllAsync()
        {
            return await _StoreRepository.AsNoTracking().Include(a => a.User).ToListAsync();
        }

        public async Task<Store?> GetStoreByIdsAsync(string id)
        {
            return await _StoreRepository.AsNoTracking().Include(a => a.User).Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Store> GetWithNamNotRepeatAndNotTheSameIdAsync(string id, string name)
        {
            return await _StoreRepository.AsNoTracking()
                .FirstOrDefaultAsync(s => s.Name.ToLower().Trim() == name.ToLower().Trim() && id != s.Id);


        }

        public async Task<bool> StoreWithNameExistsAsync(string storeName)
        {
            return await _StoreRepository.AnyAsync(s => s.Name.ToLower().Trim() == storeName.ToLower().Trim());
        }
    }
}
