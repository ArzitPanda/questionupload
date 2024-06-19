using Microsoft.EntityFrameworkCore;
using questionupload.Data;
using questionupload.Data.Model;
using questionupload.Data.Repository.impl;
using System.Threading.Tasks;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    
}
