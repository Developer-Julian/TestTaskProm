using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TestTaskProm.Domain.Entities;

namespace TestTaskProm.DAL.Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
    }
}
