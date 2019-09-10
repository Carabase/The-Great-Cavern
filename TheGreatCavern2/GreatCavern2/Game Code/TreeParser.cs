using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public static class TreeParser
    {
        public static int Parse(List<DialogueTreeNode> Tree, NPC Person)
        {
            DialogueTreeNode currentBranch = Tree[0];

            while (true)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc(Person.Name + ": " + currentBranch.line);

                foreach (DialogueTreeChoice option in currentBranch.choices.Values)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc(option.option);
                }

                string input = null;
                while (true)
                {
                    input = Globals.GetInput();

                    if (currentBranch.choices.ContainsKey(input))
                    {
                        break;
                    }

                    Globals.WindowFrame.DisplayTextToFlowDoc("Pick one of the dialogue options.");
                }


                if (currentBranch.choices[input].result < 0)
                {
                    return currentBranch.choices[input].result;
                }

                currentBranch = Tree[currentBranch.choices[input].result];
            }
        }
    }
}
