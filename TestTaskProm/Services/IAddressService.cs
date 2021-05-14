using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskProm.Dto.Models.V1;

namespace TestTaskProm.Web.Services
{
    public interface IAddressService
    {
        Task<List<CountryDto>> GetCountriesAsync();
        Task<List<ProvinceDto>> GetProvincesAsync(int countryId);
    }
}
