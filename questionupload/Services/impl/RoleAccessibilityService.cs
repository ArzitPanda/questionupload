namespace questionupload.Services.impl
{
    using questionupload.Data.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RoleAccessibilityService : IRoleAccessibilityService
    {
        private readonly IRoleAccessibilityRepository _roleAccessibilityRepository;

        public RoleAccessibilityService(IRoleAccessibilityRepository roleAccessibilityRepository)
        {
            _roleAccessibilityRepository = roleAccessibilityRepository;
        }

        public async Task<List<RoleAccessibility>> GetRoleAccessibilitiesByRoleIdAsync(int roleId)
        {
            return await _roleAccessibilityRepository.GetAsync(ra => ra.RoleId == roleId);
        }

        public async Task<List<RoleAccessibility>> GetRoleAccessibilitiesByAccessibilityIdAsync(int accessibilityId)
        {
            return await _roleAccessibilityRepository.GetAsync(ra => ra.AccessibilityId == accessibilityId);
        }

        public async Task<RoleAccessibility> AddRoleAccessibilityAsync(RoleAccessibility roleAccessibility)
        {
            return await _roleAccessibilityRepository.AddAsync(roleAccessibility);
        }

        public async Task DeleteRoleAccessibilityAsync(int roleId, int accessibilityId)
        {
            var roleAccessibility = await _roleAccessibilityRepository
                .GetAsync(ra => ra.RoleId == roleId && ra.AccessibilityId == accessibilityId);

            if (roleAccessibility != null)
            {
              /*  await _roleAccessibilityRepository.DeleteAsync(roleAccessibility);*/
            }
        }
    }

}
