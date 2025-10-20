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
    }
}
