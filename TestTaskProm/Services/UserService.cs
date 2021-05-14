using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskProm.Common;
using TestTaskProm.Common.Exceptions;
using TestTaskProm.DAL.Identity.Models;
using TestTaskProm.Web.Models;

namespace TestTaskProm.Web.Services
{
    internal sealed class UserService: IUserService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser> RegisterUserAsync(RegisterModel userInfo)
        {
            Guard.ArgumentNotNull(userInfo, nameof(userInfo));

            var existingUser = await this.userManager.FindByEmailAsync(userInfo.Login);
            if (existingUser != null)
            {
                throw new ValidationException("User with this login already registered")
                {
                    Details = { { "Login", existingUser.Email } }
                };
            }

            var user = new ApplicationUser
            {
                Email = userInfo.Login,
                ProvinceId = userInfo.ProvinceId,
                CountryId = userInfo.CountryId,
                UserName = userInfo.Login
            };

            var result = await this.userManager.CreateAsync(user, userInfo.Password);
            if (!result.Succeeded)
            {
                throw new ValidationException("Can't register user")
                {
                    Details = { { "InnerException", string.Join(Environment.NewLine, result.Errors.Select(x => x.Description)) } }
                };
            }

            return user;
        }
    }
}
