using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.DAL.Data.Models
{
    public interface IAuditableEntity
    {
         DateTime CreatedAt { get; set; }
         DateTime? UpdatedAt { get; set; }
    }
}
