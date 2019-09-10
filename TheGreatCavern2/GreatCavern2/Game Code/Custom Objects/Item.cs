using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public class Item
    {
        public Item(string Name, List<string> AltNames, int Location, string Description, string Movable, int BeenDiscovered, string Discovery, Action Use, Action Open, bool IsOpen)
        {
            this.Name = Name;
            this.AltNames = AltNames;
            this.Location = Location;
            this.Description = Description;
            this.Movable = Movable;
            this.BeenDiscovered = BeenDiscovered;
            this.Discovery = Discovery;
            this.Use = Use;
            this.Open = Open;
            this.IsOpen = IsOpen;
        }

        public string Name { get; set; }
        public List<string> AltNames { get; set; }
        public int Location { get; set; }
        public string Description { get; set; }
        public string Movable { get; set; }
        public int BeenDiscovered { get; set; }
        public string Discovery { get; set; }
        public Action Use { get; set; }
        public Action Open { get; set; }
        public bool IsOpen { get; set; }

    }
}
