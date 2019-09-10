using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public static class ItemUse
    {
        public static void LitTorch()
        {
            if (Globals.CurrentLocation == 4)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("The light from the torch clears the darkness away.");
                Globals.Locations[4].Name = "Cave Fork";
                Globals.Locations[4].Description = Descriptions.Description_4X;
                Globals.Locations[4].LookDescription = Descriptions.Look_Description_4X;
                Globals.Locations[4].Image = Properties.Resources.CaveFork;
                Globals.Locations[4].North = 6;
                Globals.Locations[4].South = 8;
                Globals.Locations[4].West = -996;
                Globals.answering = 0; 
            }
            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("Use with what?");
            }
        }

        public static void Sword()
        {
            if (Globals.CurrentLocation == 3)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You draw your sword and attempt to engage the knight in combat.");
                Globals.WindowFrame.DisplayTextToFlowDoc("However, the knight is in full armour and you have no idea what you're doing.");
                Globals.WindowFrame.DisplayTextToFlowDoc("The knight finishes you off without much difficulty.");
                Globals.Alive = 0;
                Globals.answering = 0;
            }
            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You swing around your sword. Swish! Swoosh!");
            }
        }


        public static void NoUse()
        {
            Globals.WindowFrame.DisplayTextToFlowDoc("Use with what?");
        }

        public static void NoOpen()
        {
            Globals.WindowFrame.DisplayTextToFlowDoc("You can't open that.");
        }

        public static void OpenDoor1()
        {
            if (!Globals.Items[8].IsOpen)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You open the door. Lucky it wasn't locked.");
                Globals.Locations[6].North = 7;
                Globals.Items[8].IsOpen = true;
            }
            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("The door is already open.");
            }
        }

        public static void OpenMuddyChest()
        {
            if (!Globals.Items[9].IsOpen)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You open the chest. The lock has long since rusted away.");
                Globals.WindowFrame.DisplayTextToFlowDoc("Inside you find an unlit torch.");
                Globals.Items[1].Location = 2;
                Globals.Items[9].IsOpen = true;
            }
            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("The chest is already open.");
            }
        }
    }
}
