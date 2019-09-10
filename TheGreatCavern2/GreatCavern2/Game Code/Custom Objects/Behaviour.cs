using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public abstract class Behaviour
    {
        public Dictionary<string, List<DialogueTreeNode>> DialogueTrees = new Dictionary<string, List<DialogueTreeNode>>();

        public abstract void StartTurn();
        public abstract void Dialogue();
        public abstract void EndTurn();
        
    }
}
