using Microsoft.EntityFrameworkCore;
using questionupload.Data;
using questionupload.Data.Model;
using questionupload.Data.Repository.impl;
using System.Threading.Tasks;

public class RoleAccessibilityRepository : Repository<RoleAccessibility>, IRoleAccessibilityRepository
{
    public RoleAccessibilityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    // Implement specific methods for RoleAccessibility entity if needed
}
