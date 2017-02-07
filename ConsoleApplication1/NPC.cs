using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class NPC
    {
        public NPC(int Location, string Name, string Behaviour, string Dialogue, int TimesSeen)
        {
            this.Location = Location;
            this.Name = Name;
            this.Behaviour = Behaviour;
            this.Dialogue = Dialogue;
            this.TimesSeen = TimesSeen;
        }

        public int Location { get; set; }
        public string Name { get; set; }
        public string Behaviour { get; set; }
        public string Dialogue { get; set; }
        public int TimesSeen { get; set; }
    }
}
