using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestTaskProm.Domain.Entities;

namespace TestTaskProm.DAL.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Country>> GetCountriesAsync();
        Task<List<Province>> GetProvincesAsync(int countryId);
        Task<Country> GetCountryAsync(int countryId);
        Task<Province> GetProvinceAsync(int countryId, int provinceId);
    }
}
