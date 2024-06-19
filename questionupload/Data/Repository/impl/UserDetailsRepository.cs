using Microsoft.EntityFrameworkCore;
using questionupload.Data;
using questionupload.Data.Model;
using questionupload.Data.Repository.impl;
using System.Threading.Tasks;

public class UserDetailsRepository : Repository<UserDetails>, IUserDetailsRepository
{
    public UserDetailsRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    // Implement specific methods for UserDetails entity if needed
}
