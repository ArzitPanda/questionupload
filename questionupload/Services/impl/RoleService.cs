namespace questionupload.Services.impl
{
    using questionupload.Data.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllAsync();
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            return await _roleRepository.AddAsync(role);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            await _roleRepository.UpdateAsync(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            if (role != null)
            {
                await _roleRepository.DeleteAsync(role);
            }
        }
    }

}
