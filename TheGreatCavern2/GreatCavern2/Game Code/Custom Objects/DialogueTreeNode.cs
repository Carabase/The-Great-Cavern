using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public class DialogueTreeNode
    {
        public DialogueTreeNode(string line, Dictionary<string, DialogueTreeChoice> choices)
        {
            this.line = line;
            this.choices = choices;
        }

        public string line { get; set; }
        public Dictionary<string, DialogueTreeChoice> choices { get; set; }

    }
}
