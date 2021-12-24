using Repository.EnumsAction;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class ActionPlayer : IBaseModel
    {
        public int Id { get; set; }
        public int Min { get; set; }
        public ActionsType ActionType { get; set; }
        public Player Player { get; set; }
    }
}
