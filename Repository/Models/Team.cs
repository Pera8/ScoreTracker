using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository.Models
{
    public class Team : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public League League { get; set; }
        public List<Player> Players { get; set; }
    }
}
