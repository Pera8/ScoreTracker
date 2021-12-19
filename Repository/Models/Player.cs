using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;

namespace Repository.Models
{
    public class Player : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Team Team { get; set; }
        public List<ActionPlayer>  ActionPlayers { get; set; }
    }
}
