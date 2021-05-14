using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskProm.DAL.Identity.Models;
using TestTaskProm.Web.Models;

namespace TestTaskProm.Web.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> RegisterUserAsync(RegisterModel userInfo);
    }
}
