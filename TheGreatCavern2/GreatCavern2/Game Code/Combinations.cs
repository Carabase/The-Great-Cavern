using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    // A class that contains methods for all combinations of items that do something
    public static class Combinations
    {
        // Burns the letter 
        public static void LetterBurning ()
        {
            Globals.Items[7].Location = -1;
            Globals.WindowFrame.DisplayTextToFlowDoc("Congratulations! You've lit your letter on fire and watched as it burnt to a crisp. I hope you read it first.");
        }

        // Turns an unlit Torch into a lit one
        public static void TorchLighting ()
        {
            Globals.Items[1].Location = -1;
            Globals.Items[2].Location = -100;
            Globals.WindowFrame.DisplayTextToFlowDoc("You manage to light the torch by sticking it into the burning bush.");
        }
    }
}
