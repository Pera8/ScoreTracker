using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class User: IdentityUser<int> , IBaseModel
    {
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(100)]
        
        public string? Phone { get; set; }
        //public Role Role { get; set; }

    }
}
