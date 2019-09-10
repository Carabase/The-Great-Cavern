using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GreatCavern2;

namespace GreatCavern2
{
    class Program
    {
        public static void Logic()
        {
            //Initialize all globals
            Initialize();

            //Print out Intro
            Intro();

            //Check for save files
            SaveTest();

            //Main Loop
            while (Globals.Alive == 1 && Globals.GameState == 0)
            {
                //Executes a 'turn' of the game
                Execute();
            }

            //Prints your results
            Result();

        }

        // Prints out Intro
        public static void Intro()
        {
            Globals.WindowFrame.DisplayTextToFlowDoc("Welcome to THE GREAT CAVERN");
            Globals.WindowFrame.DisplayTextToFlowDoc("Thanks for playing.");
            Globals.WindowFrame.DisplayTextToFlowDoc("Press 'help' for instructions");
        }

        // Initializes Everything in the game and makes it globablly accesible
        public static void Initialize()
        {
            // Locations
            // Create all the Event Objects to populate the event slot
            // Genericize this //
                                      // Name                                                // Alternative Names                  // N  // E  // S  // W  // U  // D       // Description           // Look Description      // Times Visited   // Image File 
            Location L0 = new Location("Cave Entrance"       , new List<string>(new string[] { "cave","entrance","cavern"})        , -995,    2,    9,    1, -993, -991, Descriptions.Description_0, Descriptions.Look_Description_0, 1, Properties.Resources.CaveEntrance);
            Location L1 = new Location("Tunnel near Entrance", new List<string>(new string[] { "cave","tunnel"})                   , -996,    0, -996,    4, -992, -991, Descriptions.Description_1, Descriptions.Look_Description_1, 0, Properties.Resources.CavernTunnel);
            Location L2 = new Location("Grassy Knoll"        , new List<string>(new string[] { "hill" , "knoll" })                 ,    5,    3,   10,    0, -993, -991, Descriptions.Description_2, Descriptions.Look_Description_2, 0, Properties.Resources.GrassyKnoll); 
            Location L3 = new Location("Forest Clearing"     , new List<string>(new string[] { "clearing", "forest" })             , -989, -989, -989,    2, -993, -991, Descriptions.Description_3, Descriptions.Look_Description_3, 0, Properties.Resources.ForestClearing);
            Location L4 = new Location("Darkness"            , new List<string>(new string[] { "darkness", "dark" })               , -990,    1, -990, -990, -992, -991, Descriptions.Description_4, Descriptions.Look_Description_4, 0, Properties.Resources.Darkness);
            Location L5 = new Location("Arid Plain"          , new List<string>(new string[] { "plain" })                          , -988, -986,    2, -995, -993, -991, Descriptions.Description_5, Descriptions.Look_Description_5, 0, Properties.Resources.AridPlain);
            Location L6 = new Location("Room with Door"      , new List<string>(new string[] { "room" })                           , -994, -996,    4, -996, -992, -991, Descriptions.Description_6, Descriptions.Look_Description_6, 0, Properties.Resources.RoomDoor);
            Location L7 = new Location("Storeroom"           , new List<string>(new string[] { "storeroom" })                      , -996, -996,    6, -996, -992, -991, Descriptions.Description_7, Descriptions.Look_Description_7, 0, Properties.Resources.StoreRoom);
            Location L8 = new Location("Abandoned Mine Shaft", new List<string>(new string[] { "mine", "shaft" })                  ,    4, -996, -996, -997, -992, -991, Descriptions.Description_8, Descriptions.Look_Description_8, 0, Properties.Resources.MineShaft);
            Location L9 = new Location("Trail"               , new List<string>(new string[] { "trail" })                          ,    0,   10, -987, -995, -993, -991, Descriptions.Description_9, Descriptions.Look_Description_9, 0, Properties.Resources.SignPath);
            Location L10 = new Location("Small River"        , new List<string>(new string[] { "stream" })                         ,    2, -985, -985,    9, -993, -991, Descriptions.Description_10, Descriptions.Look_Description_10, 0, Properties.Resources.SmallRiver);

            Globals.Locations = new List<Location>(new Location[] { L0, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10 });
            //

            //  Items
       
            Item I0 = new Item("A Stone"                  , new List<string>(new string[] { "stone" })                    ,   -1, Descriptions.Item_Description_0, "y", 0, Descriptions.Discover_Description_0, new Action(ItemUse.NoUse), new Action(ItemUse.NoOpen), false);
            Item I1 = new Item("An Unlit Torch"           , new List<string>(new string[] { "torch" })                    ,   -1, Descriptions.Item_Description_1, "y", 1, Descriptions.Discover_Description_1, new Action(ItemUse.NoUse), new Action(ItemUse.NoOpen), false);
            Item I2 = new Item("A Lit Torch"              , new List<string>(new string[] { "torch" })                    ,   -1, Descriptions.Item_Description_2, "y", 1, Descriptions.Discover_Description_2, new Action(ItemUse.LitTorch), new Action(ItemUse.NoOpen), false);
            Item I3 = new Item("A Half-Eaten Apple"       , new List<string>(new string[] { "apple" })                    ,   -1, Descriptions.Item_Description_3, "y", 0, Descriptions.Discover_Description_3, new Action(ItemUse.NoUse), new Action(ItemUse.NoOpen), false);
            Item I4 = new Item("A Blue Stone"             , new List<string>(new string[] { "stone" })                    ,    1, Descriptions.Item_Description_4, "y", 0, Descriptions.Discover_Description_4, new Action(ItemUse.NoUse), new Action(ItemUse.NoOpen), false);
            Item I5 = new Item("A Burning Bush"           , new List<string>(new string[] { "bush" })                     ,    5, Descriptions.Item_Description_5, "n", 1, Descriptions.Discover_Description_5, new Action(ItemUse.NoUse), new Action(ItemUse.NoOpen), false);
            Item I6 = new Item("The Snicker Snacker Blade", new List<string>(new string[] { "blade", "sword" })           ,    7, Descriptions.Item_Description_6, "y", 0, Descriptions.Discover_Description_6, new Action(ItemUse.Sword), new Action(ItemUse.NoOpen), false);
            Item I7 = new Item("A Worn Letter"            , new List<string>(new string[] { "letter" })                   , -100, Descriptions.Item_Description_7, "y", 1, Descriptions.Discover_Description_7, new Action(ItemUse.NoUse), new Action(ItemUse.NoOpen), false);
            Item I8 = new Item("A Door"                   , new List<string>(new string[] { "door" })                     ,    6, Descriptions.Item_Description_8, "n", 1, Descriptions.Discover_Description_8, new Action(ItemUse.NoUse), new Action(ItemUse.OpenDoor1), false);
            Item I9 = new Item("A Muddy Chest"            , new List<string>(new string[] { "chest" })                    ,    2, Descriptions.Item_Description_9, "n", 1, Descriptions.Discover_Description_9, new Action(ItemUse.NoUse), new Action(ItemUse.OpenMuddyChest), false);
            Item I10 = new Item("A Small River"           , new List<string>(new string[] { "river" })                    ,   10, Descriptions.Item_Description_10, "n", 1, Descriptions.Discover_Description_10, new Action(ItemUse.NoUse), new Action(ItemUse.NoOpen), false);
            Item I11 = new Item("A Sign Post"             , new List<string>(new string[] { "sign", "post" })             ,    9, Descriptions.Item_Description_7, "n", 1, Descriptions.Discover_Description_7, new Action(ItemUse.NoUse), new Action(ItemUse.NoOpen), false);

            Globals.Items = new List<Item>(new Item[] { I0, I1, I2, I3, I4, I5, I6, I7, I8, I9, I10 });

            // Initializes inventory
            Globals.Inventory = new List<string>(new string[] { });
            foreach (Item thing in Globals.Items)
            {
                if (thing.Location == -100)
                {
                    Globals.Inventory.Add(thing.Name);
                }
            }
            Globals.WindowFrame.UpdateInv(Globals.Inventory);

            // Create all Combinations

            // Ones that do Something
            Globals.Combinations.Add(new ItemCombination("An Unlit Torch", "A Burning Bush", new Action(Combinations.TorchLighting)));
            Globals.Combinations.Add(new ItemCombination("A Burning Bush", "A Worn Letter", new Action(Combinations.LetterBurning)));
            Globals.Combinations.Add(new ItemCombination("A Lit Torch", "A Worn Letter", new Action(Combinations.LetterBurning)));

            // Ones that don't, but say something unique
            Globals.Combinations.Add(new ItemCombination("A Blue Stone", "A Worn Letter", "You rub the blue stone on the letter accomplishing very little in the process"));
            Globals.Combinations.Add(new ItemCombination("An Unlit Torch", "A Worn Letter", "A letter isn't good replacement for flint and tinder."));


            // Create NPCs

            NPC NPC0 = new NPC("Old Miner"     , new List<string>(new string[] { "miner" })            , 8, new OldMinerBehaviour()     , 0);
            NPC NPC1 = new NPC("Templar Knight", new List<string>(new string[] { "knight", "templar" }), 3, new TemplarKnightBehaviour(), 0);

            Globals.NPCS = new List<NPC>(new NPC[] { NPC0, NPC1 });

            // Create Dialogue Trees for NPCS
            NPC0.Brain.DialogueTrees.Add("FirstMeeting",
                new List<DialogueTreeNode>(new DialogueTreeNode[] {
                new DialogueTreeNode("Hey, you there! What are you doing here? .........",
                new Dictionary<string, DialogueTreeChoice>{
                {"1", new DialogueTreeChoice("1.) I've got a wedding to get to and no time to dawdle.", 1) } ,
                {"2", new DialogueTreeChoice("2.) Buzz off, old man!", -1) } }),

                new DialogueTreeNode("I wouldn't reccomend going this way. Vile creatures have moved into these mines",
                new Dictionary<string, DialogueTreeChoice>{
                {"1", new DialogueTreeChoice("1.) Thanks for the advice but I must be on my way.", -1)} }) }));

            NPC1.Brain.DialogueTrees.Add("FirstMeeting",
                new List<DialogueTreeNode>(new DialogueTreeNode[] {
                new DialogueTreeNode("Leave this sacred grove and never come back or forfeit your life knave.",
                new Dictionary<string, DialogueTreeChoice>{
                {"1", new DialogueTreeChoice("1.) Have it your way.", -1) } ,
                {"2", new DialogueTreeChoice("2.) I refuse!", -2) }
                })}));

            // Dictionaries

            foreach (Location place in Globals.Locations)
            {
                Globals.LocationDictionary.AddRange(place.AltNames);
            }

            foreach (Item thing in Globals.Items)
            {
                Globals.ItemDictionary.AddRange(thing.AltNames);
            }

            foreach (NPC person in Globals.NPCS )
            {
                Globals.NPCDictionary.AddRange(person.AltNames);
            }
            
            // Movement Errors
            
            Globals.MovementErrors.Add(-1000, "You can't go north");
            Globals.MovementErrors.Add(-999, "You can't go east");
            Globals.MovementErrors.Add(-998, "You can't go south");
            Globals.MovementErrors.Add(-997, "You can't go west");
            Globals.MovementErrors.Add(-996, "Unsurprisingly, you fail to walk through the cave wall." + "\n" + "Instead, you bump your head. Ouch!");
            Globals.MovementErrors.Add(-995, "You briefly consider trying to find a way around the mountains before realizing that the detour would take weeks.");
            Globals.MovementErrors.Add(-994, "As much as you would like to head that direction, you have not yet mastered the art of walking through doors.");
            Globals.MovementErrors.Add(-993, "There's nowhere to go up other than the heavens yonder");
            Globals.MovementErrors.Add(-992, "There's nothing down but the ground beneath your feet");
            Globals.MovementErrors.Add(-991, "There's nothing up there other than the cave ceiling");
            Globals.MovementErrors.Add(-990, "You stumble forward in what you believe to be that direction.");
            Globals.MovementErrors.Add(-989, "You'd rather not get lost in the forest.");
            Globals.MovementErrors.Add(-988, "There's a large gorge to the north. You have no way of crossing it.");
            Globals.MovementErrors.Add(-987, "Heading back to town may not be the best idea. You distinctly remember skipping your tab at the inn.");
            Globals.MovementErrors.Add(-986, "There's nothing to the east except arid dessert. You don't have the time to dawdle.");
            Globals.MovementErrors.Add(-985, "You could wade across the shallow river, but it's not worth getting your boots wet for.");
        }

        // Looks if you have a save file and if you do, gives you the option to load it    
        public static void SaveTest()
        {
            try
            {
                string path = "C:\\Users\\Public\\Documents\\savefile.txt";
                string[] lines = System.IO.File.ReadAllLines(@path);

                Globals.WindowFrame.DisplayTextToFlowDoc("You have a previous save.");
        
                while (true)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("Would you like to load it?");
                    string input = Globals.GetInput();
                    if (input == "yes" || input == "y")
                    {
                        break;
                    }
                    else if (input == "no" || input == "n")
                    {
                        return;
                    }
                }
                

                int linecounter = 0;
                linecounter += 1; // GlobalVariables
                linecounter += 1; // PreviousLocation
                Globals.PreviousLocation = Convert.ToInt32(lines[linecounter]);
                linecounter += 1; // Update PreviousLocation
                linecounter += 1; // Knight Counter
                Globals.KnightCounter = Convert.ToInt32(lines[linecounter]);
                linecounter += 1; // Update knightcounter    
                linecounter += 1; // CurrentLocation
                Globals.CurrentLocation = Convert.ToInt32(lines[linecounter]);
                linecounter += 1; // Update CurrentLocation

                linecounter += 1; // Locations Viewed
                int checker = 0;
                while (checker <= Globals.Locations.Count - 1)
                {
                    Globals.Locations[checker].TimesVisited = Convert.ToInt32(lines[linecounter]);
                    linecounter += 1;
                    checker += 1;
                }

                linecounter += 1; // Item Position
                int checker2 = 0;
                while (checker2 <= Globals.Items.Count - 1)
                {
                    Globals.Items[checker2].Location = Convert.ToInt32(lines[linecounter]);
                    linecounter += 1;
                    Globals.Items[checker2].BeenDiscovered = Convert.ToInt32(lines[linecounter]);
                    linecounter += 1;
                    checker2 += 1;
                }

                linecounter += 1; // NPC State
                int checker3 = 0;
                while (checker3 <= Globals.NPCS.Count - 1)
                {
                    Globals.NPCS[checker3].Location = Convert.ToInt32(lines[linecounter]);
                    linecounter += 1;
                    Globals.NPCS[checker3].TimesSeen = Convert.ToInt32(lines[linecounter]);
                    linecounter += 1;
                    checker3 += 1;
                }
            }

            catch (IOException e)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You are starting a new game.");
            }
        }

        // A loop that gets run each time your location in the game changes
        public static void Execute()
        { 
            int Location = Globals.CurrentLocation;

            // Update Image to Current Location
            Globals.WindowFrame.UpdateLocationImage(Globals.Locations[Location].Image);
            // Update Name to Current Location
            Globals.WindowFrame.DisplayLocationName(Globals.Locations[Location].Name);
            // Update Description to Current Location
            Globals.WindowFrame.DisplayTextToFlowDoc(Globals.Locations[Location].Description);

            // Update Map to Current Location
            Globals.WindowFrame.UpdateMap(Actions.CreateNewMap());

            // Initializes answering
            Globals.answering = 1;

            // Perform NPC Behaviour
            foreach (NPC person in Globals.NPCS)
            {
                person.Brain.StartTurn();
            }

            // Start Input Loop
            
            while (Globals.answering == 1)
            {
                // Refresh Inventory
                Globals.WindowFrame.UpdateInv(Globals.Inventory);

                // Get Input
                Globals.WindowFrame.DisplayTextToFlowDoc("What do you do? ");
                string input = Globals.GetInput().ToLower();

                // Parse it, start over if input was garbage
                List<string> ParsedInput = Parser.Parse(input);
                if(ParsedInput == null)
                {
                    continue;
                }

                // Perform appropriate action for input
                Actions.Act(ParsedInput);
                // If an Action doesn't move you or somehow otherwise change answering you'll be prompted for another input
            }

        }

        // Prints out Results of your Playthrough
        public static void Result()
        {
            if (Globals.Alive == 0)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("Condolences, you have died.");
                Globals.WindowFrame.DisplayTextToFlowDoc("Thanks for playing.");
                System.Threading.Thread.Sleep(5000);
                Environment.Exit(0);
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("Congratulations, you have won the game.");
            }
        }

    }

}

