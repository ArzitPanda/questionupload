namespace questionupload.Services.impl
{
    using Microsoft.EntityFrameworkCore;
    using questionupload.Data;
    using questionupload.Data.Model;
    using questionupload.Data.Repository;
    using questionupload.Dtos.User;
    using questionupload.Services.utils;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly AppDbContext _appDbContext;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepository,IUserDetailsRepository userDetailsRepository,IRoleRepository roleRepository,AppDbContext appDbContext,ITokenService tokenService

            )
        {
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
            _roleRepository = roleRepository;
            _appDbContext = appDbContext;
            _tokenService = tokenService;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteAsync(user);
            }
        }

        public async Task<string> Signup(RequestUserDto user)
        {

        try
            {
                Role role = await _roleRepository.GetByIdAsync(2);


                User user1 = new User
                {
                    Username = user.UserName,
                    Password = user.Password,
                    Role = role,
                    RoleId = 2,
                    UserDetails = new UserDetails
                    {
                        College = user.College,
                        Dob = user.Dob,
                        Location = user.Location,
                        Qualification = user.Qualification,


                    }


                };

                User a = await _userRepository.AddAsync(user1);
                return "sucess";
            }
            catch (Exception ex)
            {   
                return ex.Message;

            }






        }

        /*   public async Task<User> GetUserByUsernameAsync(string username)
           {
               return await _userRepository.GetUserByUsernameAsync(username);
           }*/


        public async Task<string> AuthenticateAsync(LoginUserRequestDto loginDto)
        {
            var user = await _appDbContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == loginDto.UserName && u.Password == loginDto.Password);

            if (user == null)
                return null;

            var roles = new[] { user.Role.RoleName };

            var permissions = await GetUserPermissions(user.RoleId);

            return _tokenService.GenerateJwtToken(user, roles, permissions.ToArray());
        }

        private async Task<List<string>> GetUserPermissions(long roleId)
        {
            var permissions = await _appDbContext.RoleAccessibilities
                .Include(ra => ra.Accessibility)
                .Where(ra => ra.RoleId == roleId)
                .Select(ra => ra.Accessibility.AccessibilityName)
                .ToListAsync();

            return permissions;
        }



    }

}
