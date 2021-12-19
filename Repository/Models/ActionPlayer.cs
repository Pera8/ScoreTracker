using Repository.EnumsAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class ActionPlayer
    {
        public int Id { get; set; }
        public int Min { get; set; }
        public ActionsType ActionType { get; set; }
        public Player Player { get; set; }
    }
}
