using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCavern2
{
    public class Actions
    {
        public static void Act(List<string> input)
        {
            
            // Deal With All singleton Nouns
            if (!Globals.VerbDictionary.Contains(input[0]) && !Globals.MovementVerbDictionary.Contains(input[0]))
            {
                GetInfo(input[0]);
                return;
            }

            // Singleton Verbs
            if (input[0] == "save")
            {
                if (input.Count < 2 || (input[1] == "game" && input.Count < 3))
                {
                    Save();
                    return;
                }
                else
                {
                    Wrong(input, "save");
                    return;
                }
            }

            if (input[0] == "load")
            {
                if (input.Count < 2 || (input[1] == "game" && input.Count < 3))
                {
                    Load();
                    return;
                }
                else
                {
                    Wrong(input, "load");
                    return;
                }
            }

            if (input[0] == "help" ||
                input[0] == "instructions")
            {
                if (input.Count < 2)
                {
                    Help();
                    return;
                }
                else
                {
                    Wrong(input, "help");
                    return;
                }
            }

            if (input[0] == "quit" ||
                input[0] == "exit")
            {
                if (input.Count < 2)
                {
                    Exit();
                    return;
                }
                else
                {
                    Wrong(input, "quit");
                    return;
                }
            }

            if (input[0] == "inventory" ||
                input[0] == "i")
            {
                if (input.Count < 2)
                {
                    Inventory();
                    return;
                }
                else
                {
                    Wrong(input, "inventory");
                    return;
                }
            }
            // Verbs with one input
            if (input[0] == "talk")
            {
                if(input.Count == 1)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("Whom do you want to talk to?");
                    return;
                }

                if (input.Count > 2)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("You can only talk to one thing at a time.");
                    return;
                }

                if (input.Count < 3 && Globals.NPCDictionary.Contains(input[1]))
                {
                    Talk(input[1]);
                    return;
                }
         
                else
                {
                    Wrong(input, "talk to");
                    return;
                }
            }
            
            if (input[0] == "north" || input[0] == "east" || input[0] == "south" ||
                input[0] == "west" || input[0] == "up" || input[0] == "down" ||
                input[0] == "n" || input[0] == "e" || input[0] == "s" || input[0] == "w" ||
                input[0] == "u" || input[0] == "d" || input[0] == "forward") 
            {
                if (input.Count < 2)
                {
                    Move(input[0]);
                    return;
                }
                else
                {
                    Wrong(input, input[1]);
                    return;
                }
            }

            if (input[0] == "go" || input[0] == "move")
            {
                if (input.Count == 1)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("Where do you want to move to?");
                    return;
                }
                if (input.Count < 3 && (Globals.LocationDictionary.Contains(input[1]) || Globals.MovementVerbDictionary.Contains(input[1]) || Globals.SpecialDictionary.Contains(input[1])))
                {
                    Move(input[1]);
                    return;
                }
                if (input.Count == 3)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("Where do you want to move to?");
                    return;
                }
                else
                {
                    Wrong(input, "move to");
                    return;
                }
            }

            if (input[0] == "look" || input[0] == "l" || input[0] == "examine")
            {
                if ((input[0] == "look" ||input[0] == "l") && (input.Count < 2 || (input.Count < 3 && input[1] == "around")))
                {
                    Look("around");
                    return;
                }
                if (input.Count > 2 )
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("You can only look at one thing at a time.");
                    return;
                }
                if (input[0] == "examine" && input.Count < 3 && Globals.ItemDictionary.Contains(input[1]))
                {
                    Examine(input[1]);
                    return;
                }

                if ((input[0] == "look" || input[0] == "l") && input.Count < 3)
                {
                    Look(input[1]);
                    return;
                }
                
                else
                {
                    Wrong(input, input[0]);
                    return;
                }
            }

            if (input[0] == "pick" || input[0] == "get" || input[0] == "take")
            {
                if (input.Count == 1)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("What do you want to pick up?");
                    return;
                }

                if (input.Count > 2)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("You can only pick up one thing at a time.");
                    return;
                }

                if (input.Count < 3 && (Globals.ItemDictionary.Contains(input[1]) || Globals.SpecialDictionary.Contains(input[1])))
                {
                    PickUp(input[1]);
                    return;
                }
                else
                {
                    Wrong(input, "pick up");
                    return;
                }
            }

            if (input[0] == "drop")
            {
                if (input.Count == 1)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("What do you want to drop?");
                    return;
                }

                if (input.Count > 2)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("You can only drop one thing at a time.");
                    return;
                }

                if (input.Count < 3 && (Globals.ItemDictionary.Contains(input[1]) || Globals.SpecialDictionary.Contains(input[1])))
                {
                    Drop(input[1]);
                    return;
                }
                else
                {
                    Wrong(input, "drop");
                    return;
                }
            }

            if (input[0] == "use")
            {
                if (input.Count == 1)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("What do you want to use?");
                    return;
                }
 
                if (input.Count == 2 && Globals.ItemDictionary.Contains(input[1]))
                {
                    Use(input[1]);
                    return;
                }

                if (input.Count == 3 && Globals.ItemDictionary.Contains(input[1]) && Globals.ItemDictionary.Contains(input[2]))
                {
                    Combine(input[1], input[2]);
                    return;
                }
                
                else
                {
                    Wrong(input, "use");
                    return;
                }
            }

            if (input[0] == "open")
            {
                if (input.Count == 1)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("What do you want to open?");
                    return;
                }

                if (input.Count > 2)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("You can only open one thing at a time.");
                    return;
                }

                if (input.Count == 2 && Globals.ItemDictionary.Contains(input[1]))
                {
                    Open(input[1]);
                    return;
                }
                else
                {
                    Wrong(input, "open");
                    return;
                }
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("EXTREME CRITICAL ERROR!");
            }
        }

        // Moving
        public static void Move(string input)
        {
            if (input == "n" || input == "north")
            {
                if (Globals.Locations[Globals.CurrentLocation].North >= 0)
                {
                    Globals.PreviousLocation = Globals.CurrentLocation;
                    Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].North;
                    Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                    Globals.answering = 0;
                    return;
                }

                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc(Globals.MovementErrors[Globals.Locations[Globals.CurrentLocation].North]);
                    return;
                }
            }

            if (input == "e" || input == "east")
            {
                if (Globals.Locations[Globals.CurrentLocation].East >= 0)
                {
                    Globals.PreviousLocation = Globals.CurrentLocation;
                    Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].East;
                    Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                    Globals.answering = 0;
                    return;
                }

                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc(Globals.MovementErrors[Globals.Locations[Globals.CurrentLocation].East]);
                    return;
                }
            }

            if (input == "s" || input == "south")
            {
                if (Globals.Locations[Globals.CurrentLocation].South >= 0)
                {
                    Globals.PreviousLocation = Globals.CurrentLocation;
                    Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].South;
                    Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                    Globals.answering = 0;
                    return;
                }

                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc(Globals.MovementErrors[Globals.Locations[Globals.CurrentLocation].South]);
                    return;
                }
            }

            if (input == "w" || input == "west")
            {
                if (Globals.Locations[Globals.CurrentLocation].West >= 0)
                {
                    Globals.PreviousLocation = Globals.CurrentLocation;
                    Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].West;
                    Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                    Globals.answering = 0;
                    return;
                }

                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc(Globals.MovementErrors[Globals.Locations[Globals.CurrentLocation].West]);
                    return;
                }
            }

            if (input == "u" || input == "up")
            {
                if (Globals.Locations[Globals.CurrentLocation].Up >= 0)
                {
                    Globals.PreviousLocation = Globals.CurrentLocation;
                    Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].Up;
                    Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                    Globals.answering = 0;
                    return;
                }

                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc(Globals.MovementErrors[Globals.Locations[Globals.CurrentLocation].Up]);
                    return;
                }
            }

            if (input == "d" || input == "down")
            {
                if (Globals.Locations[Globals.CurrentLocation].Down >= 0)
                {
                    Globals.PreviousLocation = Globals.CurrentLocation;
                    Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].Down;
                    Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                    Globals.answering = 0;
                    return;
                }

                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc(Globals.MovementErrors[Globals.Locations[Globals.CurrentLocation].Down]);
                    return;
                }
            }

            if (input == "back")
            {
                int temp = Globals.CurrentLocation;
                Globals.CurrentLocation = Globals.PreviousLocation;
                Globals.PreviousLocation = temp;
                Globals.answering = 0;
                return;
            }

            if (input == "forward")
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("I don't know which way forward is. Please clarify a direction.");
                return;
            }

            foreach (Location place in Globals.Locations)
            {
                if (place.AltNames.Contains(input))
                {
                    if (place.North >= 0)
                    {
                        if (Globals.Locations[place.North] == Globals.Locations[Globals.CurrentLocation])
                        {
                            Globals.PreviousLocation = Globals.CurrentLocation;
                            Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].South;
                            Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                            Globals.answering = 0;
                            return;
                        }
                    }
                    if (place.East >= 0)
                    {
                        if (Globals.Locations[place.East] == Globals.Locations[Globals.CurrentLocation])
                        {
                            Globals.PreviousLocation = Globals.CurrentLocation;
                            Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].West;
                            Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                            Globals.answering = 0;
                            return;
                        }
                    }
                    if (place.South >= 0)
                    {
                        if (Globals.Locations[place.South] == Globals.Locations[Globals.CurrentLocation])
                        {
                            Globals.PreviousLocation = Globals.CurrentLocation;
                            Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].North;
                            Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                            Globals.answering = 0;
                            return;
                        }
                    }
                    if (place.West >= 0)
                    {
                        if (Globals.Locations[place.West] == Globals.Locations[Globals.CurrentLocation])
                        {
                            Globals.PreviousLocation = Globals.CurrentLocation;
                            Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].East;
                            Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                            Globals.answering = 0;
                            return;
                        }
                    }
                    if (place.Up >= 0)
                    {
                        if (Globals.Locations[place.Up] == Globals.Locations[Globals.CurrentLocation])
                        {
                            Globals.PreviousLocation = Globals.CurrentLocation;
                            Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].Down;
                            Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                            Globals.answering = 0;
                            return;
                        }
                    }
                    if (place.Down >= 0)
                    {
                        if (Globals.Locations[place.Down] == Globals.Locations[Globals.CurrentLocation])
                        {
                            Globals.PreviousLocation = Globals.CurrentLocation;
                            Globals.CurrentLocation = Globals.Locations[Globals.CurrentLocation].Up;
                            Globals.Locations[Globals.CurrentLocation].TimesVisited += 1;
                            Globals.answering = 0;
                            return;
                        }
                    }
                }
            }

            Globals.WindowFrame.DisplayTextToFlowDoc("That's not somewhere you can move to from here.");
        }

        // Looking Around or at Things
        public static void Look(string input)
        {
            if (input == "around")
            {
                bool FoundSomething = false;
                Globals.WindowFrame.DisplayTextToFlowDoc(Globals.Locations[Globals.CurrentLocation].LookDescription);

                Globals.Items.ForEach(delegate (Item thing)
                {
                    if (thing.Location == Globals.CurrentLocation && thing.BeenDiscovered == 0)
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc(thing.Discovery);
                        FoundSomething = true;
                    }
                    if (thing.Location == Globals.CurrentLocation && thing.Movable == "n")
                    {
                        FoundSomething = true;
                    }
                });

                bool check = true;
                Globals.Items.ForEach(delegate (Item thing)
                {

                    if (thing.Location == Globals.CurrentLocation && thing.Movable == "y" && thing.BeenDiscovered != 0)
                    {
                        if (check)
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("You find:");
                        }
                        Globals.WindowFrame.DisplayTextToFlowDoc(thing.Name);
                        FoundSomething = true;
                        check = false;
                    }
                });

                if (FoundSomething)
                {
                    return;
                }

                Globals.WindowFrame.DisplayTextToFlowDoc("You don't find anything.");
                return;

            }
            else
            {
                if (Globals.LocationDictionary.Contains(input))
                {
                    Location current = Globals.Locations[Globals.CurrentLocation];

                    if (current.AltNames.Contains(input))
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc(current.LookDescription);
                        return;
                    }

                    if (current.North > 0)
                    {
                        if (Globals.Locations[current.North].AltNames.Contains(input))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("It's too far away to look at.");
                            return;
                        }
                    }

                    if (current.East > 0)
                    {
                        if (Globals.Locations[current.East].AltNames.Contains(input))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("It's too far away to look at.");
                            return;
                        }
                    }

                    if (current.South > 0)
                    {
                        if (Globals.Locations[current.South].AltNames.Contains(input))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("It's too far away to look at.");
                            return;
                        }
                    }

                    if (current.West > 0)
                    {
                        if (Globals.Locations[current.West].AltNames.Contains(input))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("It's too far away to look at.");
                            return;
                        }
                    }

                    if (current.Up > 0)
                    {
                        if (Globals.Locations[current.Up].AltNames.Contains(input))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("It's too far away to look at.");
                            return;
                        }
                    }

                    if (current.Down > 0)
                    {
                        if (Globals.Locations[current.Down].AltNames.Contains(input))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("It's too far away to look at.");
                            return;
                        }
                    }

                    else
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("There isn't any " + input + " here.");
                        return;
                    }
                }

                if (Globals.ItemDictionary.Contains(input))
                {
                    Item current = null;
                    foreach (Item thing in Globals.Items)
                    {
                        if (thing.AltNames.Contains(input) &&(thing.Location == -100 || thing.Location == Globals.CurrentLocation))
                        {
                            current = thing;
                        }
                    }

                    if (current.Location == Globals.CurrentLocation && current.Movable == "y")
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("It's " + current.Name + ". You would have to pick it up to take a closer look.");
                        return;
                    }

                    if (current.Location == -100 || (current.Location == Globals.CurrentLocation && current.Movable == "n"))
                    {
                        Examine(input);
                        return;
                    }

                    else
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("There isn't " + input + " here.");
                        return;
                    }
                }

                if (Globals.NPCDictionary.Contains(input))
                {
                    NPC current = null;
                    foreach (NPC person in Globals.NPCS)
                    {
                        if (person.AltNames.Contains(input))
                        {
                            current = person;
                        }
                    }

                    if (current.Location == Globals.CurrentLocation)
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("You look at the " + input + ".");
                        return;
                    }
                    else
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("There isn't any " + current.Name + " here.");
                        return;
                    }
                }
            }
        }

        // Examining an Item
        public static void Examine(string input)
        {
            Item current = null;
            foreach (Item thing in Globals.Items)
            {
                if (thing.AltNames.Contains(input) && (thing.Location >= 0 || thing.Location == -100))
                {
                    current = thing;
                }
            }
            if (current.Location == -100)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc(current.Description);
                return;
            }
            if (current.Location == Globals.CurrentLocation && current.Movable == "n")
            {
                Globals.WindowFrame.DisplayTextToFlowDoc(current.Description);
                return;
            }
            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You can only examine something in your inventory.");
                return;
            }
        }
        
        // Inventory
        public static void Inventory()
        {
            bool HaveItems = true;
            foreach(Item thing in Globals.Items)
            {
                if(thing.Location == -100)
                {
                    if(HaveItems)
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("Your inventory contains:");
                        HaveItems = false;
                    }
                    Globals.WindowFrame.DisplayTextToFlowDoc(thing.Name);
                }
            }

            if(HaveItems)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("Your inventory contains nothing.");
            }
        }

        // Picking up an Item
        public static void PickUp(string input)
        {
            if (input == "all" || input == "everything")
            {
                bool PickedUpSomething = false;
                foreach (Item thing in Globals.Items)
                {
                    if (thing.Location == Globals.CurrentLocation && thing.Movable == "y")
                    {
                        PickedUpSomething = true;
                        Globals.WindowFrame.DisplayTextToFlowDoc("You pick up: " + thing.Name);
                        thing.Location = -100;
                        Globals.Inventory.Add(thing.Name);
                    }
                }
                if (!PickedUpSomething)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("There's nothing here for you to pick up.");
                    return;
                }
                return;
            }

            Item current = null;
            foreach (Item thing in Globals.Items)
            {
                if (thing.AltNames.Contains(input) && thing.Location > -1)
                {
                    current = thing;
                }
            }

            if (current.Location == Globals.CurrentLocation && current.Movable == "y")
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You pick up: " + current.Name);
                current.Location = -100;
                Globals.Inventory.Add(current.Name);
                return;
            }

            if (current.Location == Globals.CurrentLocation && current.Movable == "n")
            {
                Globals.WindowFrame.DisplayTextToFlowDoc(current.Name + " isn't something you can pick up.");
                return;
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("There is no " + input + " at your location.");
                return;
            }

        }

        // Dropping an Item
        public static void Drop(string input)
        {
            if (input == "all" || input == "everything")
            {
                bool PickedUpSomething = false;
                foreach (Item thing in Globals.Items)
                {
                    if (thing.Location == -100)
                    {
                        PickedUpSomething = true;
                        thing.Location = Globals.CurrentLocation;
                    }
                }
                if (!PickedUpSomething)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("There's nothing here for you to pick up.");
                    return;
                }
                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("You drop everything you have.");
                    return;
                }
            }

            Item current = null;
            foreach (Item thing in Globals.Items)
            {
                if (thing.AltNames.Contains(input) && thing.Location < -1)
                {
                    current = thing;
                }
            }

            if (current.Location == -100)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You drop: " + current.Name);
                current.Location = Globals.CurrentLocation;
                return;
            }

            if (input == "all" || input == "everything")
            {
                bool DroppedSomething = false;
                foreach (Item thing in Globals.Items)
                {
                    if (thing.Location == -100)
                    {
                        DroppedSomething = true;
                        Globals.WindowFrame.DisplayTextToFlowDoc("You drop: " + thing.Name);
                        thing.Location = Globals.CurrentLocation;
                        return;
                    }
                }
                if (!DroppedSomething)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("You don't have anything to drop.");
                    return;
                }
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You don't have any " + input + " in your inventory.");
                return;
            }

        }

        // Talking to NPCs
        public static void Talk(string input)
        {
            foreach (NPC person in Globals.NPCS)
            {
                if (person.AltNames.Contains(input))
                {
                    if (person.Location == Globals.CurrentLocation)
                    {
                        person.Brain.Dialogue();
                        return;
                    }
                    else
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("There is no " + input + " at your location.");
                    }
                }

            }
        }

        // Using an Item
        public static void Use(string input)
        {
            Item current = null;
            foreach (Item thing in Globals.Items)
            {
                if (thing.AltNames.Contains(input) && (thing.Location > -1 || thing.Location == -100))
                {
                    current = thing;
                }
            }

            if (current.Location == Globals.CurrentLocation && current.Movable == "n")
            {
                current.Use.Invoke();
                return;
            }

            if (current.Location == Globals.CurrentLocation && current.Movable == "y")
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You have to pick up the " + input + " to use it.");
                return;
            }

            if (current.Location == -100)
            {
                current.Use.Invoke();
                return;
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You can't use " + input + ".");
                return;
            }
        }

        // Opening an Item
        public static void Open(string input)
        {
            Item current = null;
            foreach (Item thing in Globals.Items)
            {
                if (thing.AltNames.Contains(input))
                {
                    current = thing;
                }
            }

            if (current.Location == Globals.CurrentLocation && current.Movable == "n")
            {
                current.Open.Invoke();
                return;
            }

            else
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You can't open " + input + ".");
                return;
            }
        }

        // Using an Item with another Item
        public static void Combine(string input1, string input2)
        {
            Item current1 = null;
            foreach (Item thing in Globals.Items)
            {
                if (thing.AltNames.Contains(input1) && (thing.Location > -1 || thing.Location == -100))
                {
                    current1 = thing;
                }
            }

            Item current2 = null;
            foreach (Item thing in Globals.Items)
            {
                if (thing.AltNames.Contains(input2) && (thing.Location > -1 || thing.Location == -100))
                {
                    current2 = thing;
                }
            }

            if(current1.Location != -100 && current1.Location != Globals.CurrentLocation)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc(current1.Name + " isn't at your location.");
                return;
            }

            if (current2.Location != -100 && current2.Location != Globals.CurrentLocation)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc(current2.Name + " isn't at your location.");
                return;
            }
            if (current1 == current2)
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("You can't use something with itself.");
                return;
            }

            foreach (ItemCombination Combi in Globals.Combinations)
            {
                if((Combi.Item1 == current1.Name && Combi.Item2 == current2.Name) || (Combi.Item1 == current2.Name && Combi.Item2 == current1.Name ))
                {
                    if (Combi.Interaction != null)
                    {
                        Combi.Interact();
                        return;
                    }
                    else
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc(Combi.error);
                        return;
                    }
                }
            }
            Globals.WindowFrame.DisplayTextToFlowDoc("You can't use those two things together");
            return;
        }

        // Identifying a Noun
        public static void GetInfo(string noun)
        {
            if (Globals.SpecialDictionary.Contains(noun))
            {
                Globals.WindowFrame.DisplayTextToFlowDoc("Invalid Input");
            }

            if (Globals.LocationDictionary.Contains(noun))
            {

                if (Globals.Locations[Globals.CurrentLocation].AltNames.Contains(noun))
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("That's where you are.");
                    return;
                }

                int currentN = Globals.CurrentLocation;
                int currentE = Globals.CurrentLocation;
                int currentS = Globals.CurrentLocation;
                int currentW = Globals.CurrentLocation;
                int currentU = Globals.CurrentLocation;
                int currentD = Globals.CurrentLocation;
                while (true)
                {
                    if (Globals.Locations[currentN].North > 0)
                    {
                        currentN = Globals.Locations[currentN].North;
                        if (Globals.Locations[currentN].AltNames.Contains(noun))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("A " + noun + " lies to the north.");
                            return;
                        }
                        continue;
                    }

                    if (Globals.Locations[currentE].East > 0)
                    {
                        currentE = Globals.Locations[currentE].East;
                        if (Globals.Locations[currentE].AltNames.Contains(noun))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("A " + noun + " lies to the east.");
                            return;
                        }
                        continue;
                    }

                    if (Globals.Locations[currentS].South > 0)
                    {
                        currentS = Globals.Locations[currentS].South;
                        if (Globals.Locations[currentS].AltNames.Contains(noun))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("A " + noun + " lies to the south.");
                            return;
                        }
                        continue;
                    }

                    if (Globals.Locations[currentW].West > 0)
                    {
                        currentW = Globals.Locations[currentW].West;
                        if (Globals.Locations[currentW].AltNames.Contains(noun))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("A " + noun + " lies to the west.");
                            return;
                        }
                        continue;
                    }

                    if (Globals.Locations[currentU].Up > 0)
                    {
                        currentU = Globals.Locations[currentU].Up;
                        if (Globals.Locations[currentU].AltNames.Contains(noun))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("A " + noun + " lies upwards.");
                            return;
                        }
                        continue;
                    }

                    if (Globals.Locations[currentD].Down > 0)
                    {
                        currentD = Globals.Locations[currentD].Down;
                        if (Globals.Locations[currentD].AltNames.Contains(noun))
                        {
                            Globals.WindowFrame.DisplayTextToFlowDoc("A " + noun + " lies downwards.");
                            return;
                        }
                        continue;
                    }

                    else
                    {
                        break;
                    }
                }

                Globals.WindowFrame.DisplayTextToFlowDoc("You don't see a " + noun + " around here.");
                return;

            }

            if (Globals.ItemDictionary.Contains(noun))
            {
                Item current = null;
                foreach (Item thing in Globals.Items)
                {
                    if (thing.AltNames.Contains(noun))
                    {
                        current = thing;
                    }
                }

                if (current.Location == Globals.CurrentLocation || current.Location == -100)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("What do you want to do with " + current.Name + "?");
                }
                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("There isn't " + current.Name + " here.");
                }
            }

            if (Globals.NPCDictionary.Contains(noun))
            {
                NPC current = null;
                foreach (NPC person in Globals.NPCS)
                {
                    if (person.AltNames.Contains(noun))
                    {
                        current = person;
                    }
                }

                if (current.Location == Globals.CurrentLocation)
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("There is a  " + current.Name + " here. Would you like to talk to them?");
                    return;
                }
                else
                {
                    Globals.WindowFrame.DisplayTextToFlowDoc("There isn't any " + current.Name + " here.");
                    return;
                }

            }

        }

        // Saving
        public static void Save()
        {
            System.IO.File.WriteAllText(@"C:\Users\Public\Documents\savefile.txt", "Global Variables");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\Documents\savefile.txt", true))
            {
                file.WriteLine("");
                file.WriteLine("PreviousLocation");
                file.WriteLine(Convert.ToString(Globals.PreviousLocation));
                file.WriteLine("knightcounter");
                file.WriteLine(Convert.ToString(Globals.KnightCounter));
                file.WriteLine("CurrentLocation");
                file.WriteLine(Convert.ToString(Globals.CurrentLocation));
                file.WriteLine("Locations Viewed");
                Globals.Locations.ForEach(delegate (Location place)
                {
                    file.WriteLine(Convert.ToString(place.TimesVisited));
                });
                file.WriteLine("Item Position");
                Globals.Items.ForEach(delegate (Item thing)
                {
                    file.WriteLine(Convert.ToString(thing.Location));
                    file.WriteLine(Convert.ToString(thing.BeenDiscovered));
                });
                file.WriteLine("NPC Status");
                Globals.NPCS.ForEach(delegate (NPC person)
                {
                    file.WriteLine(Convert.ToString(person.Location));
                    file.WriteLine(Convert.ToString(person.TimesSeen));
                });
                Globals.WindowFrame.DisplayTextToFlowDoc("You have succesfully saved.");
            }
        }

        // Instructions
        public static void Help()
        {
            Globals.WindowFrame.DisplayTextToFlowDoc("This is the list of keyboard controls.");
            Globals.WindowFrame.DisplayTextToFlowDoc("      You can move by pressing 'n', 'e', 's', and 'w'.");
            Globals.WindowFrame.DisplayTextToFlowDoc("      You can look at things or around by using 'l' or 'look'.");
            Globals.WindowFrame.DisplayTextToFlowDoc("      You can pick up items once you have looked around using 'p'.");
            Globals.WindowFrame.DisplayTextToFlowDoc("      You can view your inventory using 'i' or 'inventory'.");
            Globals.WindowFrame.DisplayTextToFlowDoc("      You can talk to an NPC using 'talk'.");
            Globals.WindowFrame.DisplayTextToFlowDoc("      You can save the game by using 'save'.");
            Globals.WindowFrame.DisplayTextToFlowDoc("      You can exit the game by typing 'quit' or 'exit'.");
        }

        // Loading
        public static void Load()
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
                Globals.WindowFrame.DisplayTextToFlowDoc("You don't have any save files.");
            }
        }

        // Exiting the Game
        public static void Exit()
        {
            Globals.WindowFrame.DisplayTextToFlowDoc("Thanks for playing.");
            System.Threading.Thread.Sleep(2000);
            Environment.Exit(0);
        }

        // Wrong Type
        public static void Wrong(List<string> input, string verb)
        {
            foreach (Location place in Globals.Locations)
            {
                foreach (string AltName in place.AltNames)
                {
                    if (input[1] == AltName)
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("You can't " + verb + " a place.");
                        return;
                    }
                }
            }

            foreach (Item thing in Globals.Items)
            {
                foreach (string AltName in thing.AltNames)
                {
                    if (input[1] == AltName)
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("You can't " + verb + " a thing.");
                        return;
                    }
                }
            }

            foreach (NPC person in Globals.NPCS)
            {
                foreach (string AltName in person.AltNames)
                {
                    if (input[1] == AltName)
                    {
                        Globals.WindowFrame.DisplayTextToFlowDoc("You can't " + verb + " a person.");
                        return;
                    }
                }
            }
        }

        public static int size = 75;

        // Make a New Map image
        public static System.Drawing.Bitmap CreateNewMap()
        {
            System.Drawing.Bitmap map = new System.Drawing.Bitmap(20 * size, 20 * size);
            CreaterDeMap(Globals.Locations[Globals.CurrentLocation], map, "start", 10 * size, 10 * size, new List <Location>( new Location[] { Globals.Locations[Globals.CurrentLocation] }), 0);
            // draw green square around current location
            using (Graphics gr = Graphics.FromImage(map))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                Pen GreenPen = new Pen(Color.Green, 3);

                // Create rectangle.
                Rectangle rect = new Rectangle(10 * size - size, 10 * size - size, 2 * size, 2 * size);

                Point point1 = new Point(9 * size, 9 * size);
                Point point2 = new Point(11 * size, 11 * size);

                Point point3 = new Point(11 * size, 9 * size);
                Point point4 = new Point(9 * size, 11 * size);

                // Draw line to screen.
                gr.FillRectangle(Brushes.White , rect);
                gr.DrawLine(GreenPen, point1, point2);
                gr.DrawLine(GreenPen, point3, point4);

                // Draw rectangle to screen.
                gr.DrawRectangle(GreenPen, rect);

            }
            return map;
        }

        public static void CreaterDeMap(Location current, System.Drawing.Bitmap map, string FromDirection, int x, int y, List<Location> Visited, int loop)
        {
            if (Visited.Contains(current) && loop > 0)
            {
                return;
            }

            loop += 1;
            Visited.Add(current);
            // Draw Square for Current Location
            using (Graphics gr = Graphics.FromImage(map))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                Pen blackPen = new Pen(Color.Black, 3);
                Rectangle rect = new Rectangle(x - size, y - size, 2 * size, 2 * size);
                gr.DrawRectangle(blackPen, rect);

                StringFormat drawFormat = new StringFormat();
                drawFormat.Alignment = StringAlignment.Center;
                gr.DrawString(current.Name, new Font("Tahoma", 8), Brushes.Black, rect, drawFormat);

            }

            // Write Location Name in Center of Square


            // Check Each direction for a two way path
            foreach (Location place in Globals.Locations)
            {
                if (place.North >= 0 && current.South >= 0)
                {
                    if (Globals.Locations[place.North] == current && Globals.Locations[current.South] == place && place.TimesVisited > 0 && FromDirection != "south")
                    {

                        using (Graphics gr = Graphics.FromImage(map))
                        {
                            gr.SmoothingMode = SmoothingMode.AntiAlias;
                            Pen blackPen = new Pen(Color.Black, 3);
                            Point point1 = new Point(x, y + size);
                            Point point2 = new Point(x, y + (2 * size));
                            gr.DrawLine(blackPen, point1, point2);
                        }

                        CreaterDeMap(place, map, "north", x, y + (3 * size), Visited, loop);
                    }
                }

                if (current.North >= 0 && place.South >= 0)
                {
                    if (Globals.Locations[place.South] == current && Globals.Locations[current.North] == place && place.TimesVisited > 0 && FromDirection != "north")
                    {
                        // Start making line of length 5 at (x, y-5)
                        using (Graphics gr = Graphics.FromImage(map))
                        {
                            gr.SmoothingMode = SmoothingMode.AntiAlias;

                            Pen blackPen = new Pen(Color.Black, 3);

                            Point point1 = new Point(x, y - size);
                            Point point2 = new Point(x, y - (2 * size));

                            // Draw line to screen.
                            gr.DrawLine(blackPen, point1, point2);
                        }
                        CreaterDeMap(place, map, "south", x, y - (3 * size), Visited, loop);

                    }
                }

                if (current.West >= 0 && place.East >= 0)
                {
                    if (Globals.Locations[place.East] == current && Globals.Locations[current.West] == place && place.TimesVisited > 0 && FromDirection != "west")
                    {
                        // Start making line of length 5 at (x-5, y)
                        using (Graphics gr = Graphics.FromImage(map))
                        {
                            gr.SmoothingMode = SmoothingMode.AntiAlias;

                            Pen blackPen = new Pen(Color.Black, 3);

                            Point point1 = new Point(x - size, y);
                            Point point2 = new Point(x - 2 * size, y);

                            // Draw line to screen.
                            gr.DrawLine(blackPen, point1, point2);
                        }
                        CreaterDeMap(place, map, "east", x - (3 * size), y, Visited, loop);
                    }
                }

                if (current.East >= 0 && place.West >= 0)
                {
                    if (Globals.Locations[place.West] == current && Globals.Locations[current.East] == place && place.TimesVisited > 0 && FromDirection != "east")
                    {
                        // Start making line of length 5 at (x+5, y)
                        using (Graphics gr = Graphics.FromImage(map))
                        {
                            gr.SmoothingMode = SmoothingMode.AntiAlias;

                            Pen blackPen = new Pen(Color.Black, 3);

                            Point point1 = new Point(x + size, y);
                            Point point2 = new Point(x + (2 * size), y);

                            // Draw line to screen.
                            gr.DrawLine(blackPen, point1, point2);
                        }
                        CreaterDeMap(place, map, "west", x + (3 * size), y, Visited, loop);
                    }
                }
            }
        }
    }
}
        
    