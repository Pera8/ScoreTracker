using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Role : IdentityRole<int>, IBaseModel
    {
        public bool IsDeleted { get; set; }
        public DateTime? DataCreated { get; set; }
        public DateTime? DataModified { get; set; }
        public string Description { get; set; }
    }
}
