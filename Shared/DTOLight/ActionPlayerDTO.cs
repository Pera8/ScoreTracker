

using Repository.EnumsAction;

namespace Shared.DTOLight
{
    public class ActionPlayerDTO
    {
        public int Id { get; set; }
        public int Min { get; set; }
        public ActionsType ActionType { get; set; }
        public int PlayerId { get; set; }
    }
}
