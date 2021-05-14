using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskProm.Common;
using TestTaskProm.Web.Extensions;
using TestTaskProm.Web.Services;

namespace TestTaskProm.Web.Controllers.V1
{

    using ValidationException = TestTaskProm.Common.Exceptions.ValidationException;

    [Route("/v1/country")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Fields

        private readonly IAddressService addressService;

        #endregion

        #region Constructor

        public UserController(IAddressService addressService)
        {
            this.addressService = addressService;
        }

        #endregion

        #region Actions

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{countryid}/province")]
        public async Task<ActionResult> GetProvinciesAsync([FromRoute][Required] int countryId)
        {
            try
            {
                var provinces = await this.addressService.GetProvincesAsync(countryId);
                return this.Ok(provinces);
            }
            catch (ValidationException ex)
            {
                var details = ex.ToValidationProblemDetails();
                return this.NotFound(details);
            }
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("")]
        public async Task<ActionResult> GetCountriesAsync()
        {
            try
            {
                var countries = await this.addressService.GetCountriesAsync();
                return this.Ok(countries);
            }
            catch (ValidationException ex)
            {
                var details = ex.ToValidationProblemDetails();
                return this.NotFound(details);
            }
        }

        #endregion
    }
}
