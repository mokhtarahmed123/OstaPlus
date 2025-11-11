using OSTA.DAL.Entities;

namespace OSTA.DAL.Interfaces
{
    public interface IRoleRepository

    {

        public Task<bool> RoleNameIsFound(string Name);
        public Task<bool> NameISFoundWithAnotherId(string Name, string Id);
        public Task<string> GetIdByName(string Name);

        public Task<RoleApplication> GetByName(string Name);
        public Task<List<RoleApplication>> GetAll();
    }
}
