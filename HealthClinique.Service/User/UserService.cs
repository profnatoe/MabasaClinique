using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HealthClinique.Data.Models;
using HealthClinique.Service.Patients;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HealthClinique.Service.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IPatientService _patient;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration config, IPatientService patient)
        {
            _userManager = userManager;
            _config = config;
            _patient = patient;
        }
        public async Task<ServiceResponse<bool>> RegisterPatient(RegisterUser user)
        {
            var now = DateTime.UtcNow;
            var patientAccount = await _userManager.FindByEmailAsync(user.Email);

            if (patientAccount != null)
                return new ServiceResponse<bool>()
                {
                    Data = false,
                    IsSuccess = false,
                    Message = $"Account with this email address {patientAccount.Email} already exist!",
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
            
            var patient = new Patient
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                IdentityNumber = user.IdentityNumber,
                Gender = user.Gender,
                User = identityUser
            };

            if (result.Succeeded)
            {
                await _patient.CreatePatient(patient);
                
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

        public async Task<ServiceResponse<string>> LoginPatient(LoginUser user)
        {
            var patient = await _userManager.FindByEmailAsync(user.Email);
            var now = DateTime.UtcNow;
           
            if (patient != null)
            {
                var result = await _userManager.CheckPasswordAsync(patient, user.Password);

                if (!result)
                    return new ServiceResponse<string>()
                    {
                        Message = "Invalid Password",
                        IsSuccess = false,
                        Data = "Could not login",
                        Time = now
                    };

                var claims = new[]
                {
                    new Claim("Email", user.Email),
                    new Claim(ClaimTypes.NameIdentifier, patient.Id)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AuthSettings:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _config["AuthSettings:Issuer"],
                    audience: _config["AuthSettings:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

                return new ServiceResponse<string>()
                {
                    Message = tokenAsString,
                    IsSuccess = true,
                    Data = patient.Id,
                    Time = now
                };
            }

            return new ServiceResponse<string>()
            {
                Data = "No Id found!",
                Message = $"Could not Login, Patient's Email Address: {user.Email} is not registered in the system!",
                Time = now,
                IsSuccess = false
            };
        }
    }
}