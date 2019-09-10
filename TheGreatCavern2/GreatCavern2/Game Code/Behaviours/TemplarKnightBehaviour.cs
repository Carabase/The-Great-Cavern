using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    class TemplarKnightBehaviour : Behaviour
    {
        public override void StartTurn()
        {
          
            if (Globals.NPCS[1].Location == Globals.CurrentLocation)
            {
                this.Dialogue();
            }
        }
    

        public override void Dialogue()
        {
            if (Globals.NPCS[1].TimesSeen == 0)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("The silence of the forest grove is interrupted by the sound of a galloping horse.");
                Globals.WindowFrame.DisplayTextToFlowDoc("A rider approaches. As he gets closer, you see that he's a knight in full armour.");
                int result = TreeParser.Parse(DialogueTrees["FirstMeeting"], Globals.NPCS[1]);
                Globals.NPCS[1].TimesSeen = 1;
                if (result == -2)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc(Globals.NPCS[1].Name + ": Your loss.");
                    Globals.WindowFrame.DisplayTextToFlowDoc("The knight runs you through on the spot.");
                    Globals.Alive = 0;
                    Globals.answering = 0;
                }
                Globals.WindowFrame.DisplayTextToFlowDoc("The knight stoicly waits for you to leave his grove.");
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You have broken your promise to the knight.");
                Globals.WindowFrame.DisplayTextToFlowDoc("As you approach the grove once again, the knight appears once more and removes your head from it's shoulders with one stroke of his longsword.");
                Globals.Alive = 0;
                Globals.answering = 0;
            }
        }

        public override void EndTurn()
        {

        }
    }
}
