using System;
using System.Threading.Tasks;
using HealthClinique.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HealthClinique.Service.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        public async Task<ServiceResponse<bool>> RegisterPatient(RegisterUser user)
        {
            var now = DateTime.UtcNow;
            
            if (user == null)
                return new ServiceResponse<bool>()
                {
                    Data = false,
                    IsSuccess = false,
                    Message = "Model null!",
                    Time = now
                };

            if (user.Password != user.ConfirmPassword)
                return new ServiceResponse<bool>()
                {
                    Data = false,
                    Message = "Password Don't match",
                    Time = now,
                    IsSuccess = false
                };

            var identityUser = new IdentityUser
            {
                Email = user.Email,
                UserName = user.Email
            };

            var result = await  _userManager.CreateAsync(identityUser, user.Password);

            if (result.Succeeded)
            {
                return new ServiceResponse<bool>()
                {
                    IsSuccess = true,
                    Data = true,
                    Message = $"Successfully Registered patient. Generated Id is: {identityUser.Id}",
                    Time = now
                };
            }

            return new ServiceResponse<bool>()
            {
                IsSuccess = false,
                Data = false,
                Message = "An error occured!",
                Time = now
            };
        }

        public ServiceResponse<bool> LoginPatient(LoginUser user)
        {
            throw new System.NotImplementedException();
        }
    }
}