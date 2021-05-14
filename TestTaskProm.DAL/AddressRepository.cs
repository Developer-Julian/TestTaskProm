using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskProm.Common;
using TestTaskProm.DAL.Interfaces;
using TestTaskProm.Domain.Entities;

namespace TestTaskProm.DAL
{
    public sealed class AddressRepository: IAddressRepository
    {
        private readonly TestTaskPromContext context;
        public AddressRepository(TestTaskPromContext context)
        {
            this.context = context;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            return await context.Countries
                .AsNoTracking()
                .Where(x => !x.IsRemoved)
                .ToListAsync();
        }

        public async Task<Country> GetCountryAsync(int countryId)
        {
            return await context.Countries
                .AsNoTracking()
                .Where(x => !x.IsRemoved)
                .FirstOrDefaultAsync(x => x.Id == countryId);
        }

        public async Task<Province> GetProvinceAsync(int countryId, int provinceId)
        {
            return await context.Countries
                .AsNoTracking()
                .Where(x => !x.IsRemoved)
                .Where(x => x.Id == countryId)
                .SelectMany(x => x.Provinces)
                .Where(x => !x.IsRemoved)
                .FirstOrDefaultAsync(x => x.Id == provinceId);
        }

        public async Task<List<Province>> GetProvincesAsync(int countryId)
        {
            return await context.Countries
                .AsNoTracking()
                .Include(x => x.Provinces)
                .Where(x => !x.IsRemoved)
                .Where(x => x.Id == countryId)
                .SelectMany(x => x.Provinces)
                .Where(x => !x.IsRemoved)
                .ToListAsync();
        }
    }
}
