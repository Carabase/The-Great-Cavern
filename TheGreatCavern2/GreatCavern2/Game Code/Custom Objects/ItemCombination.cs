using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public class ItemCombination
    {
        public ItemCombination(string Item1, string Item2, Action Interaction )
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.Interaction = Interaction;
        }

        public ItemCombination(string Item1, string Item2, string error)
        {
            this.Item1 = Item1;
            this.Item2 = Item2;
            this.error = error;
        }

        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string error { get; set; }
        public  Action Interaction { get; set; }

        public void Interact()
        {
            Interaction.Invoke();
        }

    }
}
