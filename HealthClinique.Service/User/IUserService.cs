﻿using System.Threading.Tasks;
using HealthClinique.Data.Models;

namespace HealthClinique.Service.User
{
    public interface IUserService
    {
         Task<ServiceResponse<bool>> RegisterPatient(RegisterUser user);
         ServiceResponse<bool> LoginPatient(LoginUser user);
    }
}