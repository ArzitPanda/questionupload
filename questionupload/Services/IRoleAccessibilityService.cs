namespace questionupload.Services
{
    using questionupload.Data.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRoleAccessibilityService
    {
        Task<List<RoleAccessibility>> GetRoleAccessibilitiesByRoleIdAsync(int roleId);
        Task<List<RoleAccessibility>> GetRoleAccessibilitiesByAccessibilityIdAsync(int accessibilityId);
        Task<RoleAccessibility> AddRoleAccessibilityAsync(RoleAccessibility roleAccessibility);
        Task DeleteRoleAccessibilityAsync(int roleId, int accessibilityId);
    }

}
