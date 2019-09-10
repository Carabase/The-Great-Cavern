using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    class OldMinerBehaviour : Behaviour
    {
        
        public override void StartTurn()
        {
            if (Globals.NPCS[0].Location == Globals.CurrentLocation && Globals.NPCS[0].TimesSeen == 0)
            {
                Dialogue();
            }
        }

        public override void Dialogue()
        {
            if (Globals.NPCS[0].TimesSeen == 0)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("The man leaning against the wall gets up in startled shock at seeing you.");
                TreeParser.Parse(DialogueTrees["FirstMeeting"], Globals.NPCS[0]);
                Globals.NPCS[0].TimesSeen = 1;
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You talk to the old man, but he's given up on you.");
                Globals.WindowFrame.DisplayTextToFlowDoc(Globals.NPCS[0].Name + ":" + " Do what you will.");
            }

        }

        public override void EndTurn()
        {
           
        }

    }
}
