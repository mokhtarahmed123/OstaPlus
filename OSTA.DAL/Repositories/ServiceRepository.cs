using CBS.Infrastructure.Bases;
using Microsoft.EntityFrameworkCore;
using OSTA.DAL.Context;
using OSTA.DAL.Entities;
using OSTA.DAL.Interfaces;

namespace OSTA.DAL.Repositories
{
    public class ServiceRepository : GenericRepositoryAsync<Service>, IServiceRepository
    {
        private readonly DbSet<Service> _services;

        public ServiceRepository(OstaContext dbContext) : base(dbContext)
        {
            _services = dbContext.Set<Service>();
        }
        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await _services
                .AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.ServiceRequest)
                .ToListAsync();
        }
        public async Task<Service?> GetByIdAsync(string id)
        {
            return await _services
                .AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.ServiceRequest)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Service>> GetByCategoryAsync(string categoryName)
        {
            return await _services
                .AsNoTracking()
                .Include(s => s.Category)
                .Where(s => s.Category.Name.ToLower() == categoryName.ToLower())
                .ToListAsync();
        }
        public async Task<bool> CategoryWithNameIsFound(string categoryName)
        {
            return await _services
                .AsNoTracking()
                .Include(s => s.Category)
                .AnyAsync(s => s.Category.Name.ToLower() == categoryName.ToLower());
        }
        public async Task<int> CountOfServices()
        {
            return await _services.CountAsync();
        }
    }
}
