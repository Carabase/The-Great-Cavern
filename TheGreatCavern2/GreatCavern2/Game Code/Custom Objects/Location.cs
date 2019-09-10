using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public class Location
    {
        public Location(string Name, List<string> AltNames, int North, int East, int South, int West, int Up, int Down, string Description, string LookDescription, int TimesVisited, System.Drawing.Bitmap Image)
        {
            this.Name = Name;
            this.AltNames = AltNames;
            this.North = North;
            this.East = East;
            this.South = South;
            this.West = West;
            this.Up = Up;
            this.Down = Down;
            this.Description = Description;
            this.LookDescription = LookDescription;
            this.TimesVisited = TimesVisited;
            this.Image = Image;
        }

        public string Name { get; set; }
        public List<string> AltNames { get; set; }
        public int North { get; set; }
        public int East { get; set; }
        public int South { get; set; }
        public int West { get; set; }
        public int Up { get; set; }
        public int Down { get; set; }
        public string Description { get; set; }
        public string LookDescription { get; set; }
        public int TimesVisited { get; set; }
        public System.Drawing.Bitmap Image { get; set; }
}
}
