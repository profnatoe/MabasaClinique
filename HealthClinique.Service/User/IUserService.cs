using System.Threading.Tasks;
using HealthClinique.Data.Models;

namespace HealthClinique.Service.User
{
    public interface IUserService
    {
         Task<ServiceResponse<bool>> RegisterPatient(RegisterUser user);
         Task<ServiceResponse<string>> LoginPatient(LoginUser user);
    }
}