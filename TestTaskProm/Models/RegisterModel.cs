using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskProm.Web.Models
{
    public class RegisterModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
    }
}
