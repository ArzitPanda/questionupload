namespace questionupload.Services
{
    using questionupload.Data.Model;
    using System.Threading.Tasks;

    public interface IUserDetailsService
    {
        Task<UserDetails> GetUserDetailsByIdAsync(int userId);
        Task<UserDetails> UpdateUserDetailsAsync(UserDetails userDetails);
        Task DeleteUserDetailsAsync(int userId);
    }

}
