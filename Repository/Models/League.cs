using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;

namespace Repository.Models
{
    public class League: IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public List<Team> Teams { get; set; }
        public List<Season> Seasons { get; set; }

    }
}
