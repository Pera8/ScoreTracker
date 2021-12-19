
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Season : IBaseModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Number { get; set; }
        public League League { get; set; }                                          
    }
}
