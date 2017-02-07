using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleApplication1;

namespace TheGreatCavern
{

    class MainLoop
    {

        static void Main(string[] args)
        {
            Globals globals = new Globals();
            ItemManager iWiz = new ItemManager();
            List<Item> Items = iWiz.Initialize();
            NPCManager nWiz = new NPCManager();
            List<NPC> NPCs = nWiz.Initialize();
            List<Location> Locations = InitializeLocations();

            Console.WriteLine("Welcome to THE GREAT CAVERN");
            Console.WriteLine("Thanks for playing.");
            Console.WriteLine("Press '?' for instructions");

            SaveTest(globals, Items, Locations, NPCs);

            while (globals.alive == 1)
            {
                Execute(globals, Items, Locations, NPCs);
            }
        }

        public static List<Location> InitializeLocations()
        {
            Descriptions descriptions = new Descriptions();

            //                         N     E     S     W            Descriptions           Events          Look_Descriptions     Times Looked

            Location L0 = new Location( -995,    2, -995,    1, descriptions.Description_0, "NoEvent", descriptions.Look_Description_0, 0);
            Location L1 = new Location( -996,    0, -996,    4, descriptions.Description_1, "NoEvent", descriptions.Look_Description_1, 0);
            Location L2 = new Location(    5,    3, -998,    0, descriptions.Description_2, "NoEvent", descriptions.Look_Description_2, 0); 
            Location L3 = new Location(-1000, -999, -998,    2, descriptions.Description_3, "KnightEvent", descriptions.Look_Description_3, 0);
            Location L4 = new Location(    6,    1,    8, -997, descriptions.Description_4, "DarknessEvent", descriptions.Look_Description_4, 0);
            Location L5 = new Location(-1000, -999,    2, -997, descriptions.Description_5, "NoEvent", descriptions.Look_Description_5, 0);
            Location L6 = new Location( -994, -999,    4, -997, descriptions.Description_6, "DoorEvent", descriptions.Look_Description_6, 0);
            Location L7 = new Location( -996, -996,    6, -997, descriptions.Description_7, "NoEvent", descriptions.Look_Description_7, 0);
            Location L8 = new Location(    4, -996, -996, -997, descriptions.Description_8, "NoEvent", descriptions.Look_Description_8, 0);

            List<Location> Locations = new List<Location>(new Location[] { L0, L1, L2, L3, L4, L5, L6, L7, L8 });
            return Locations;

        }
            
        public static void SaveTest(Globals globals, List<Item> Items, List<Location> Locations, List<NPC> NPCs)
        {
            try
            {
                string path = "C:\\Users\\Public\\Documents\\savefile.txt";
                string[] lines = System.IO.File.ReadAllLines(@path);
                Console.WriteLine("You are loading a previous save.");
                int linecounter = 0;
                linecounter += 1; // GlobalVariables
                linecounter += 1; // PreviousLocation
                globals.PreviousLocation = Convert.ToInt32(lines[linecounter]);
                linecounter += 1; // Update PreviousLocation
                linecounter += 1; // Knight Counter
                globals.knightcounter = Convert.ToInt32(linecounter);
                linecounter += 1; // Update knightcounter    
                linecounter += 1; // CurrentLocation
                globals.CurrentLocation = Convert.ToInt32(linecounter);
                linecounter += 1; // Update CurrentLocation

                linecounter += 1; // Locations Viewed
                int checker = 0;
                    while (checker <= Locations.Count - 1)
                        {
                        Locations[checker].TimesLooked = Convert.ToInt32(linecounter);
                        linecounter += 1;
                        checker += 1;
                        }

                linecounter += 1; // Item Position
                int checker2 = 0;
                while (checker2 <= Items.Count - 1)
                {
                    Items[checker2].Location = Convert.ToInt32(linecounter);
                    linecounter += 1;
                    checker2 += 1;
                }

                linecounter += 1; // NPC State
                int checker3 = 0;
                while (checker3 <= NPCs.Count - 1)
                {
                    NPCs[checker3].Location = Convert.ToInt32(linecounter);
                    linecounter += 1;
                    NPCs[checker3].TimesSeen = Convert.ToInt32(linecounter);
                    linecounter += 1;
                    checker3 += 1;
                }
            }

            catch (IOException e)
            {
                Console.WriteLine("You are starting a new game.");
            }
        }

        public static void Execute(Globals globals, List<Item> Items, List<Location> Locations, List<NPC> NPCs)
        {
            Actions aWiz = new Actions();
            Events eWiz = new Events();
            int Location = globals.CurrentLocation;

            // Events that precede Location Description
            if (Locations[Location].Event == "DarknessEvent")
            {
                eWiz.DarknessEvent(globals, Items);
                if (globals.CurrentLocation == globals.PreviousLocation)
                {
                    return;
                }
            }

            // Give Location Description
            Console.WriteLine(Locations[Location].Description);

            // Perform NPC Behaviour
            for list in NPCS
                {
                list[2]();
            }

            // Events that follow Location Description
            if (Locations[Location].Event == "KnightEvent")
            {
                eWiz.knightencounter(globals);
                return;
            }

            if (Locations[Location].Event == "DoorEvent")
            {
                eWiz.DoorEvent(globals, Locations);
            }

            // Update Location 
            globals.PreviousLocation = globals.CurrentLocation;

            // Start Input Loop
            int answering = 1;
            int locationMarker = 0;
            while (answering == 1)
            {
                if (locationMarker >= 1)
                {
                    Console.WriteLine(Locations[Location].Description);
                }
                Console.WriteLine("What do you do? ");
                var input = Console.ReadLine();

                if (input == "?")
                {
                    aWiz.Help();
                    locationMarker += 1;
                    Console.WriteLine("");
                    continue;
                }

                if (input == "n" || input == "s" || input == "e" || input == "w")
                {
                    if (aWiz.Moving(input, globals, Locations) == true)
                    {
                        Console.WriteLine("");
                        return;
                    }
                    else
                    {
                        locationMarker += 1;
                        Console.WriteLine("");
                        continue;
                    }
                }

                if (input == "l")
                {
                    Console.WriteLine("");
                    aWiz.Look(globals, Locations, Items);
                    locationMarker += 1;
                    Console.WriteLine("");
                    continue;
                }

                if (input == "p")
                {
                    Console.WriteLine("");
                    PickUp();
                    locationMarker += 1;
                    Console.WriteLine("");
                    continue;
                }

                if (input == "i")
                {
                    Console.WriteLine("");
                    Inventory();
                    locationMarker += 1;
                    Console.WriteLine("");
                    continue;
                }

                if (input == "z")
                {
                    aWiz.save(globals, Locations, Items, NPCs);
                    locationMarker += 1;
                    Console.WriteLine("");
                    continue;
                }

                if (input == "t")
                {
                    Talk();
                    locationMarker += 1;
                    Console.WriteLine("");
                    continue;
                }

                if (input == "quit" || input == "exit")
                {
                    Console.WriteLine("Thanks for playing.");
                    System.Threading.Thread.Sleep(3000);
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("Invalid Answer");
                    Console.WriteLine("");
                    locationMarker += 1;
                }
            }

        }

    }

}

