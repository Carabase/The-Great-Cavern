using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Item
    {
        public Item(int Location, string Name, string Description, string Handability)
        {
            this.Location = Location;
            this.Name = Name;
            this.Description = Description;
            this.Handability = Handability;
        }

        public int Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Handability { get; set; }

    }
}
