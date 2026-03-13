using System;
using System.Collections.Generic;
using System.Text;

namespace WebService.DAL
{
    public interface IAuditableEntity
    {
         DateTime CreatedAt { get; set; }
         DateTime? UpdatedAt { get; set; }
    }
}
