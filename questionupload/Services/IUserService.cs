namespace questionupload.Services
{
    using questionupload.Data.Model;
    using questionupload.Dtos.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {


        Task<string> Signup(RequestUserDto user);

        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
       Task<string> AuthenticateAsync(LoginUserRequestDto loginDto);
        Task DeleteUserAsync(int id);
     /*   Task<User> GetUserByUsernameAsync(string username);*/
    }

}
