namespace questionupload.Services
{
    using questionupload.Data.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoleService
    {
        Task<Role> GetRoleByIdAsync(int id);
        Task<List<Role>> GetAllRolesAsync();
        Task<Role> CreateRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
    }

}
