using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Events
    {
        // Events

        // 1
        public void knightencounter(Globals globals)
        {
            if (globals.knightcounter == 0)
            {
                Console.WriteLine("Quietly at first, but then louder and louder you hear the pattering sound of hooves.");
                Console.WriteLine("A group of armoured and weaponed knights burst through the thicket and start circling round you on their horses.");
                Console.WriteLine("Their leader approaches you and says,'You are trespassing on sacred ground. Leave and never return or you won't live to regret it'.");
                int answering = 1;
                while (answering == 1)
                {
                    Console.WriteLine("What is your decision? Leave or Stay ");
                    string ans = Console.ReadLine();

                    if (ans == "Leave")
                    {
                        Console.WriteLine("'You have made the right decision, but I warn you never to return here.'");
                        globals.knightcounter = 1;
                        globals.CurrentLocation = globals.PreviousLocation;
                        return;
                    }
                    if (ans == "Stay")
                    {
                        Console.WriteLine("'I am sorry it has come to this,' says the knight as he brings his mace smashing down on your skull.");
                        Console.WriteLine("Your lifeless bodys sags and crumples to the ground.");
                        globals.alive = 0;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Answer");
                    }
                }
            }

            if (globals.knightcounter == 1)
            {
                Console.WriteLine("But that silence is not kept for long as the knights appear once more.");
                Console.WriteLine("'You did not heed our warning and now you must pay the price', says the knight as he decapitates you with one fell swoop.");
                Console.WriteLine("Your head flies off your shoulders and lands on the ground with a thunk, your body following close behind.");
                globals.alive = 0;
                return;
            }
        }

        // 2
        public void DarknessEvent(Globals globals, List<Item> Items)
        {
            if (Items[2].Location == -100)
            {
                return;
            }

            else
            {
                Console.WriteLine("The light continues fading until you find yourself in pitch blackness.");
                int answering = 1;
                int x = 0;
                while (answering == 1)
                {
                    if (x >= 1)
                    {
                        Console.WriteLine("You find yourself in pitch blackness.");
                    }

                    Console.WriteLine("Where do you go? ");
                    string ans = Console.ReadLine();

                    if (ans == "n")
                    {
                        Console.WriteLine("You stumble forward through the darkness in the direction you believe to be north.");
                        x += 1;
                        continue;
                    }

                    if (ans == "e")
                    {
                        Console.WriteLine("After stumbling eastwards for a way, you see light off in the distance.");
                        Console.WriteLine("Eventually you reach a cave entrance, one that seems awfully familiar.");
                        Console.WriteLine("You quickly realize you're right back where you started.");
                        globals.CurrentLocation = globals.PreviousLocation;
                        return;
                    }

                    if (ans == "s")
                    {
                        Console.WriteLine("You stumble forward through the darkness in the direction you believe to be south.");
                        x += 1;
                        continue;
                    }

                    if (ans == "w")
                    {
                        Console.WriteLine("You stumble forward through the darkness in the direction you believe to be west.");
                        x += 1;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Answer");
                    }
                }
            }
        }

        // 3
        public void DoorEvent(Globals globals, List<Location> Locations)
        {
            int answering = 1;
            while (answering == 1)
            {
                Console.WriteLine("Do you want to try to open the door? (Y/N)");
                string ans = Console.ReadLine();
                if (ans == "Y")
                {
                    Console.WriteLine("You try to open the door. Luckily for you it wasn't locked and swings open.");
                    Locations[6].North = 7;
                    return;
                }
                if (ans == "N")
                {
                    answering = 0;
                }

                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            }
        }
    }
}
