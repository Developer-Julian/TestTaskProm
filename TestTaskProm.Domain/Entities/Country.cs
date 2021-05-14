using System;
using System.Collections.Generic;
using System.Text;
using TestTaskProm.Domain.Interfaces;

namespace TestTaskProm.Domain.Entities
{
    public class Country: IAuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Province> Provinces { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime EditedOn { get; set; }

        public string EditedBy { get; set; }

        public bool IsRemoved { get; set; }
    }
}
