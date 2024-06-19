using Microsoft.EntityFrameworkCore;
using questionupload.Data;
using questionupload.Data.Model;
using questionupload.Data.Repository.impl;
using System.Threading.Tasks;

public class AccessibilityRepository : Repository<Accessibility>, IAccessibilityRepository
{
    public AccessibilityRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    // Implement specific methods for Accessibility entity if needed
}
