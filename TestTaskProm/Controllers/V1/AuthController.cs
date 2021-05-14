using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestTaskProm.Common;
using TestTaskProm.Common.Exceptions;
using TestTaskProm.DAL.Identity.Models;
using TestTaskProm.Dto;
using TestTaskProm.Web.Extensions;
using TestTaskProm.Web.Models;
using TestTaskProm.Web.Services;
using ValidationException = TestTaskProm.Common.Exceptions.ValidationException;

namespace TestTaskProm.Web.Controllers.V1
{
    [Route("/v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Fields

        private IUserService userService;
        private SignInManager<ApplicationUser> signInManager;

        #endregion

        #region Constructor

        public AuthController(
            IUserService userService,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
        }

        #endregion

        #region Actions

        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("")]
        public async Task<ActionResult> RegisterAsync([FromBody] RegisterModel userInfo)
        {
            Guard.ArgumentNotNull(userInfo, nameof(userInfo));
            Guard.ArgumentPropertyNotNullOrEmpty(userInfo.Login, nameof(userInfo), nameof(userInfo.Login));
            Guard.ArgumentPropertyNotNullOrEmpty(userInfo.Password, nameof(userInfo), nameof(userInfo.Password));

            try
            {
                await this.userService.RegisterUserAsync(userInfo);
            }
            catch (ValidationException ex)
            {
                var details = ex.ToValidationProblemDetails();
                return this.BadRequest(details);
            }

            return this.StatusCode(StatusCodes.Status201Created);
        }

        #endregion
    }
}
