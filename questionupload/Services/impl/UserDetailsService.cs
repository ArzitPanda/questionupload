namespace questionupload.Services.impl
{
    using questionupload.Data.Model;
    using System.Threading.Tasks;

    public class UserDetailsService : IUserDetailsService
    {
        private readonly IUserDetailsRepository _userDetailsRepository;

        public UserDetailsService(IUserDetailsRepository userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }

        public async Task<UserDetails> GetUserDetailsByIdAsync(int userId)
        {
            return await _userDetailsRepository.GetByIdAsync(userId);
        }

        public async Task<UserDetails> UpdateUserDetailsAsync(UserDetails userDetails)
        {
            await _userDetailsRepository.UpdateAsync(userDetails);
            return userDetails;
        }

        public async Task DeleteUserDetailsAsync(int userId)
        {
            var userDetails = await _userDetailsRepository.GetByIdAsync(userId);
            if (userDetails != null)
            {
                await _userDetailsRepository.DeleteAsync(userDetails);
            }
        }
    }

}
