using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Location
    {
        public Location(int North, int East, int South, int West, string Description, string Event, string LookDescription, int TimesLooked)
        {
            this.North = North;
            this.East = East;
            this.South = South;
            this.West = West;
            this.Description = Description;
            this.Event = Event;
            this.LookDescription = LookDescription;
            this.TimesLooked = TimesLooked;
        }
        public int North { get; set; }
        public int East { get; set; }
        public int South { get; set; }
        public int West { get; set; }
        public string Description { get; set; }
        public string Event { get; set; }
        public string LookDescription { get; set; }
        public int TimesLooked { get; set; }
    }
}
