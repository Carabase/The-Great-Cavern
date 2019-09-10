using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public class NPC
    {
        public NPC(string Name, List<string> AltNames, int Location, Behaviour Brain, int TimesSeen)
        {
            this.Name = Name;
            this.AltNames = AltNames;
            this.Location = Location;
            this.Brain = Brain;
            this.TimesSeen = TimesSeen;
        }

        public string Name { get; set; }
        public List<string> AltNames { get; set; }
        public int Location { get; set; }
        public Behaviour Brain { get; set; }
        public int TimesSeen { get; set; }
    }
}
