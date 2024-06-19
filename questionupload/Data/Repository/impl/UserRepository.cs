using questionupload.Data.Model;

namespace questionupload.Data.Repository.impl
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
