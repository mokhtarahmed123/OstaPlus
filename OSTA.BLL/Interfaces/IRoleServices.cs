using OSTA.BLL.DTOs.RoleDTOs;

namespace OSTA.BLL.Interfaces
{
    public interface IRoleServices
    {
        Task<string> CreateRoleAsync(CreateRoleDto createRole);
        Task<string> UpdateRoleAsync(string Name, EditRoleDto editRole);
        Task<string> DeleteRoleAsync(string roleName);
        Task<List<GetAllRolesNameDto>> GetAllRolesAsync();
    }
}
