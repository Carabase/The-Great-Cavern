using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public class DialogueTreeChoice
    {
        public DialogueTreeChoice(string option, int result)
        {
            this.option = option;
            this.result = result;
        }

        public string option { get; set; }
        public int result { get; set; }
    }
}
