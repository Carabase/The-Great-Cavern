using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public static class Globals
    {
        // The window the game uses
        public static MainWindow WindowFrame;

        // Global states and variables
        public static int Alive = 1;
        public static int GameState = 0;
        public static int PreviousLocation = 0;
        public static int CurrentLocation = 0;
        public static int KnightCounter = 0;
        public static int answering = 1;
        public static List<string> Inventory;

        // Lists of all entities in the game
        public static List<Location> Locations;
        public static List<NPC> NPCS;
        public static List<Item> Items;

        // Helper Data
        public static List<ItemCombination> Combinations = new List<ItemCombination>(new ItemCombination[] { });
        public static Dictionary<int, string> MovementErrors = new Dictionary<int, string>();

        // Word Dictionaries for Parsing
        public static List<string> SpecialDictionary = new List<string>(new string[] { "back", "all", "everything", "game", "around" });
        public static List<string> AdjectiveDictionary = new List<string>(new string[] { "unlit", "lit", "blue", "old", "muddy" });
        public static List<string> LocationDictionary = new List<string>(new string[] { });
        public static List<string> ItemDictionary = new List<string>(new string[] { });
        public static List<string> NPCDictionary = new List<string>(new string[] { });
        public static List<string> VerbDictionary = new List<string>(new string[] {"save", "load", "move", "go", "help", "instructions", "l", "look", "examine", "pick", "get", "take", "open", "drop", "quit", "exit", "use", "give", "talk", "inventory", "i" });
        public static List<string> MovementVerbDictionary = new List<string>(new string[] {"n", "e", "s", "w", "u", "d", "north", "east", "south", "west", "up", "down", "forward"});

        // Gets you an input from the textbox anywhere in th code and formats it nicely
        public static string GetInput()
        {
            string input = null;
            while (input == null)
            {
                if (Globals.WindowFrame.response != null)
                {
                    input = Globals.WindowFrame.response;
                    input = input.Trim();
                }
            }
            return input;
        }
    }
}
