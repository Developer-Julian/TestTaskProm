using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskProm.Common.Exceptions;
using TestTaskProm.DAL.Interfaces;
using TestTaskProm.Dto.Models.V1;

namespace TestTaskProm.Web.Services
{
    internal sealed class AddressService: IAddressService
    {
        private const string CountryCacheKey = "Countries";
        private const string ProvinceCacheKey = "Country_{0}_Province";
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;
        private readonly IMemoryCache cache;
        public AddressService(
            IAddressRepository addressRepository,
            IMapper mapper,
            IMemoryCache cache)
        {
            this.addressRepository = addressRepository;
            this.mapper = mapper;
            this.cache = cache;
        }

        public async Task<List<CountryDto>> GetCountriesAsync()
        {
            if (this.cache.TryGetValue(CountryCacheKey, out List<CountryDto> result))
            {
                return result;
            }

            result = await this.GetCountriesInternalAsync();

            return result;
        }

        public async Task<List<ProvinceDto>> GetProvincesAsync(int countryId)
        {
            if (this.cache.TryGetValue(string.Format(ProvinceCacheKey, countryId), out List<ProvinceDto> result))
            {
                return result;
            }

            result = await this.GetProvinciesInternalAsync(countryId);

            return result;
        }

        #region Internal

        private async Task<List<CountryDto>> GetCountriesInternalAsync()
        {
            var countries = await this.addressRepository.GetCountriesAsync();

            if (!countries.Any())
            {
                throw new ValidationException("Can't find countries");
            }

            var result = this.mapper.Map<List<CountryDto>>(countries);
            this.cache.Set(CountryCacheKey, result, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

            return result;
        }

        public async Task<List<ProvinceDto>> GetProvinciesInternalAsync(int countryId)
        {
            var provinces = await this.addressRepository.GetProvincesAsync(countryId);
            if (!provinces.Any())
            {
                throw new ValidationException("Can't find provinces")
                {
                    Details = { { "CountryId", "Does not contains provinces" } }
                };
            }

            var result = this.mapper.Map<List<ProvinceDto>>(provinces);
            this.cache.Set(string.Format(ProvinceCacheKey, countryId), result, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

            return result;
        }

        #endregion
    }
}
