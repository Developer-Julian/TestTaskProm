using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TestTaskProm.Domain.Interfaces;

namespace TestTaskProm.Domain.Entities
{
    public class Province: IAuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public DateTime EditedOn { get; set; }

        public string EditedBy { get; set; }

        public bool IsRemoved { get; set; }

        public virtual Country Country { get; set; }
    }
}
