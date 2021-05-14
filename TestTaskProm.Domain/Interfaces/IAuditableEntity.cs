using System;
using System.Collections.Generic;
using System.Text;

namespace TestTaskProm.Domain.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
        DateTime EditedOn { get; set; }
        string EditedBy { get; set; }
        bool IsRemoved { get; set; }
    }
}
