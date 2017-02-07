using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Actions
    {
        // Saving
        public void save(Globals globals, List<Location> Locations, List<Item> Items, List<NPC> NPCs)
        {
            System.IO.File.WriteAllText(@"C:\Users\Public\Documents\savefile.txt", "Global Variables");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\Documents\savefile.txt", true))
            {
                file.WriteLine("PreviousLocation");
                file.WriteLine(Convert.ToString(globals.PreviousLocation));
                file.WriteLine("knightcounter");
                file.WriteLine(Convert.ToString(globals.knightcounter));
                file.WriteLine("CurrentLocation");
                file.WriteLine(Convert.ToString(globals.CurrentLocation));
                file.WriteLine("Locations Viewed");
                Locations.ForEach(delegate (Location place)
                {
                    file.WriteLine(Convert.ToString(place.TimesLooked));
                });
                file.WriteLine("Item Position");
                Items.ForEach(delegate (Item thing)
                {
                    file.WriteLine(Convert.ToString(thing.Location));
                });
                NPCs.ForEach(delegate (NPC person)
                {
                    file.WriteLine(Convert.ToString(person.Location));
                    file.WriteLine(Convert.ToString(person.TimesSeen));
                });
                Console.WriteLine("You have succesfully saved.");
            }
        }


        // Instructions
        public void Help()
        {
            Console.WriteLine("This is the list of keyboard controls.");
            Console.WriteLine("      You can move by pressing 'n', 'e', 's', and 'w'.");
            Console.WriteLine("      You can look around for items using 'l'.");
            Console.WriteLine("      You can pick up items once you have looked around using 'p'.");
            Console.WriteLine("      You can view your inventory using 'i'.");
            Console.WriteLine("      You can talk to an NPC using 't'.");
            Console.WriteLine("      You can save the game by using 'z'.");
            Console.WriteLine("      You can exit the game by typing 'quit' or 'exit'.");
        }

        // Moving
        public Boolean Moving(string dir, Globals globals, List<Location> Locations)
        {

            if (dir == "n")
            {
                if (Locations[globals.CurrentLocation].North >= 0)
                {
                    globals.CurrentLocation = Locations[globals.CurrentLocation].North;
                    return true;
                }

                // Case for not being able to leave to the north
                if (Locations[globals.CurrentLocation].North == -1000)
                {
                    Console.WriteLine("You can't go north");
                }

                //Case for there being cave wall in your way   
                if (Locations[globals.CurrentLocation].North == -996)
                {
                    Console.WriteLine("Unsurprisingly, you fail to walk through the cave wall.");
                    Console.WriteLine("Instead, you bump your head. Ouch!");
                }

                //Case for being at the Cave Entrance
                if (Locations[globals.CurrentLocation].North == -995)
                {
                    Console.WriteLine("You briefly consider trying to find a way around the mountains before realizing that the detour would take weeks.");
                }

                //Case for there being a door in the way
                if (Locations[globals.CurrentLocation].North == -994)
                {
                    Console.WriteLine("As much as you would like to head that direction, you have not yet mastered the art of walking through doors.");
                }
            }

            if (dir == "e")
            {
                if (Locations[globals.CurrentLocation].East >= 0)
                {
                    globals.CurrentLocation = Locations[globals.CurrentLocation].East;
                    return true;
                }

                // Case for not being able to leave to the East
                if (Locations[globals.CurrentLocation].East == -999)
                {
                    Console.WriteLine("You can't go east");
                }

                //Case for there being cave wall in your way   
                if (Locations[globals.CurrentLocation].East == -996)
                {
                    Console.WriteLine("Unsurprisingly, you fail to walk through the cave wall.");
                    Console.WriteLine("Instead, you bump your head. Ouch!");
                }

                //Case for being at the Cave Entrance
                if (Locations[globals.CurrentLocation].East == -995)
                {
                    Console.WriteLine("You briefly consider trying to find a way around the mountains before realizing that the detour would take weeks.");
                }
            }

            if (dir == "s")
            {
                if (Locations[globals.CurrentLocation].South >= 0)
                {
                    globals.CurrentLocation = Locations[globals.CurrentLocation].South;
                    return true;
                }

                // Case for not being able to leave to the South
                if (Locations[globals.CurrentLocation].South == -998)
                {
                    Console.WriteLine("You can't go south");
                }

                //Case for there being cave wall in your way   
                if (Locations[globals.CurrentLocation].South == -996)
                {
                    Console.WriteLine("Unsurprisingly, you fail to walk through the cave wall.");
                    Console.WriteLine("Instead, you bump your head. Ouch!");
                }

                //Case for being at the Cave Entrance
                if (Locations[globals.CurrentLocation].South == -995)
                {
                    Console.WriteLine("You briefly consider trying to find a way around the mountains before realizing that the detour would take weeks.");
                }
            }

            if (dir == "w")
            {
                if (Locations[globals.CurrentLocation].West >= 0)
                {
                    globals.CurrentLocation = Locations[globals.CurrentLocation].West;
                    return true;
                }

                // Case for not being able to leave to the West
                if (Locations[globals.CurrentLocation].West == -997)
                {
                    Console.WriteLine("You can't go west");
                }

                //Case for there being cave wall in your way   
                if (Locations[globals.CurrentLocation].West == -996)
                {
                    Console.WriteLine("Unsurprisingly, you fail to walk through the cave wall.");
                    Console.WriteLine("Instead, you bump your head. Ouch!");
                }

                //Case for being at the Cave Entrance
                if (Locations[globals.CurrentLocation].West == -995)
                {
                    Console.WriteLine("You briefly consider trying to find a way around the mountains before realizing that the detour would take weeks.");
                }
            }

            return false;
        }

        public void Look(Globals globals, List<Location> Locations, List<Item> Items)
        {
            int check = 0;
            Locations[globals.CurrentLocation].TimesLooked += 1;
            Items.ForEach(delegate (Item thing)
            {
                if (thing.Location == globals.CurrentLocation)
                {
                    check = 1;
                }
            });

            if (check == 1)
            {
                Console.WriteLine(Locations[globals.CurrentLocation].LookDescription);
                Items.ForEach(delegate (Item thing)
                {
                    if (thing.Location == globals.CurrentLocation)
                    {
                        Console.WriteLine(thing.Name);
                    }
                });
                return;
            }

            if (Locations[globals.CurrentLocation].TimesLooked == 10)
            {
                Console.WriteLine("Be careful, don't strain your eyes. You still don't find anything.");
            }
            if (Locations[globals.CurrentLocation].TimesLooked == 25)
            {
                Console.WriteLine("If anything had changed, you would have noticed by now.");
            }
            else
            {
                Console.WriteLine("You don't find anything.");
            }
       }

def PickUp():
    global CurrentLocation
    
    if Locations[CurrentLocation][7] < 1:
            print("You haven't looked to see if there is anything to pick up.")
            return
        
    CheckForItemInLocation = 0
    for list in Items:
        if list[0]==CurrentLocation:
            CheckForItemInLocation = 1
            
    if CheckForItemInLocation == 1:
        print("What do you want to pick up?")
        print("1.) Everything")
        print("2.) Nothing")
        x = 2
        for list in Items:
            if list[0]==CurrentLocation:
                x += 1
                print(str(x) + ".)", list[1])
                
        unsureofanswer = 1
        while unsureofanswer == 1:
            which = input()
            while unsureofanswer == 1:
                try:
                    val = int(which)
                except ValueError:
                    print("Invalid Choice")
                    print("What do you want to pick up?")
                    break
                if int(which)>x:
                    print("Invalid Choice")
                    print("What do you want to pick up?")
                    break
                if int(which)<=0:
                    print("Invalid Choice")
                    print("What do you want to pick up?")
                    break
                unsureofanswer = 0      
        if which == "1":
            counter = 0
            counter2 = 0
            for list in Items:
                if list[0]==CurrentLocation and list[3] == "n" and counter == 0:
                    counter += 1
                if list[0]==CurrentLocation and list[3]=="y":
                    list[0] = -100
                    counter2 += 1
            if counter > 0 and counter2 == 0:
                print("You weren't able to pick up anything.")
            if counter > 0 and counter2 > 0:
                print("You were only able to pick up some of the things.")
            if counter == 0 and counter2 > 0:
                print("You pick up everything.")
            return
        if which == "2":
            print("You pick up nothing.")
            return
        if int(which)<=x:
                counter = 0
                positionchecker=0
                for list in Items:
                    if list[0]== CurrentLocation and counter==0:
                        positionchecker+=1
                        if positionchecker == int(which)-2 and list[3]=="y" :
                            list[0] = -100
                            print("You pick up:")
                            print(list[1])
                            counter+=1
                            break
                        if positionchecker == int(which)-2 and list[3]=="n" :
                            print("You can't pick it up " + list[2])
                            counter+=1
                            break
                return        
    print("There is nothing here for you to pick up.")

def Inventory():


    print("Your inventory contains:")


    check = 0
    for list in Items:
        if list[0]==-100:
            check = 1
    if check!= 1:
        print("Absolutely Nothing!")
        return
    
    if check == 1:
        for list in Items:
            if list[0]==-100:
                print(list[1])
        print("What do you want to do?")
        print("1.) Examine an Item Closer")
        print("2.) Drop an Item")
        print("3.) Use an Item")
        print("4.) Exit Inventory")


        unsureofanswer = 1
        while unsureofanswer == 1:
            choice = input()
            while unsureofanswer == 1:
                try:
                    val = int(choice)
                except ValueError:
                    print("Invalid Choice")
                    print("What do you want to do?")
                    break
                if int(choice)>4 or int(choice)<1:
                    print("Invalid Choice")
                    print("What do you want to do?")
                    break
                unsureofanswer = 0

        #Examine an Item
        if choice == "1":
            print("Which item would you like to examine?")
            x = 1
            for list in Items:
                if list[0]==-100:
                    print(str(x) + ".)", list[1])
                    x += 1
            
            unsureofanswer = 1
            while unsureofanswer == 1:
                itemchoice = input()
                while unsureofanswer == 1:
                    try:
                        val = int(itemchoice)
                    except ValueError:
                        print("Invalid Choice")
                        print("Which item would you like to examine?")
                        break
                    if int(itemchoice)>3 or int(itemchoice)<1:
                        print("Invalid Choice")
                        print("Which item would you like to examine?")
                        break
                    unsureofanswer = 0      
            
            while x >= 1:
                if itemchoice == str(x):
                    counter = 0
                    for list in Items:
                        if list[0]==-100:
                            counter += 1
                            if counter == x:
                                print("You examine:", list[1])
                                print(list[2])
                                break
                x -= 1
            return        

        #Drop an Item    
        if choice == "2":
            print("Which item(s) do you want to drop?")
            print("1.) All of them")
            print("2.) None")
            x =3
            for list in Items:
                if list[0]==-100:
                    print(str(x) + ".)", list[1])
                    x += 1
            unsureofanswer = 1
            while unsureofanswer == 1:
                which = input()
                while unsureofanswer == 1:
                    try:
                        val = int(which)
                    except ValueError:
                        print("Invalid Choice")
                        print("Which item(s) do you want to drop?")
                        break
                    if int(which)>=x:
                        print("Invalid Choice")
                        print("Which item(s) do you want to drop?")
                        break
                    unsureofanswer = 0

            #Drop all        
            if which == "1":
                print("You drop all of them.")
                for list in Items:
                    if list[0]== -100:
                        list[0] = CurrentLocation      
                return

            #Drop None
            if which == "2":
                print("You drop none.")
                return

            #Drop Specific Item
            if int(which)<=x:
                while x > 2:
                    if which == str(x):
                        print("You drop:")
                        counter = 0
                        for list in Items:
                            if list[0]==-100:
                                counter += 1
                                if counter == x-2:
                                    list[0] = CurrentLocation
                                    print(list[1])
                                    break
                    x -= 1
                return

        #Use an Item    
        if choice == "3":
            print("Which item would you like to use?")
            x = 1
            for list in Items:
                if list[0]==-100:
                    print(str(x) + ".)", list[1])
                    x += 1
            
            unsureofanswer = 1
            while unsureofanswer == 1:
                itemchoice = input()
                while unsureofanswer == 1:
                    try:
                        val = int(itemchoice)
                    except ValueError:
                        print("Invalid Choice")
                        print("Which item would you like to use?")
                        break
                    if int(itemchoice)>x or int(itemchoice)<1:
                        print("Invalid Choice")
                        print("Which item would you like to use?")
                        break
                    unsureofanswer = 0
             
            while x >= 1:
                if itemchoice == str(x):
                    counter = 0
                    for list in Items:
                        if list[0]==-100:
                            counter += 1
                            if counter == x:
                                FirstUseItem = list
                x -= 1


            print("Do you want to use this item with:")
            
            for list in Items:
                DoYouNotHaveItems = 0
                if list[0]== -100 and list != FirstUseItem:
                    print("1.) Another item in your inventory?")
                    DoYouNotHaveItems = 0
                    break
                else:
                    DoYouNotHaveItems = 1
            if DoYouNotHaveItems == 1:
                print("1.) You have no other items in your inventory.")

            for list in Items:
                IsThereAnItemInTheEnvironment = 0
                if list[0]== CurrentLocation:
                    print("2.) Something in the environment?")
                    IsThereAnItemInTheEnvironment = 1
                    break
                else:
                    IsThereAnItemInTheEnvironment = 0
           
            if IsThereAnItemInTheEnvironment == 0:
                print("2.) There are no items in the environment.")


            print("3.) Nothing.")

            answering = 1
            while answering == 1:
                 answer = input()
                 if answer == "1" and DoYouNotHaveItems == 0:
                     break

                 if answer == "2" and IsThereAnItemInTheEnvironment == 1:
                     break

                 if answer == "3":
                     break
                    
                 else:
                     print("Invalid Choice")

            #Use the item with another item in the inventory   
            if answer == "1":
                print("Which item would you like to use with", FirstUseItem[1] + "?")
                x = 1
                for list in Items:
                    if list[0]==-100 and list != FirstUseItem:
                        print(str(x) + ".)", list[1])
                        x += 1
                unsureofanswer = 1
                while unsureofanswer == 1:
                    itemchoice = input()
                    while unsureofanswer == 1:
                        try:
                            val = int(itemchoice)
                        except ValueError:
                            print("Invalid Choice")
                            print("Which item would you like to choose?")
                            break
                        if int(itemchoice)>x or int(itemchoice)<1:
                            print("Invalid Choice")
                            print("Which item would you like to choose?")
                            break
                        unsureofanswer = 0

                #Use with a specific item        
                while x >= 1:
                    if itemchoice == str(x):
                        counter = 0
                        for list in Items:
                            if list[0]==-100 and list!=FirstUseItem:
                                counter += 1
                                if counter == x:
                                    SecondUseItem = list
                    x-=1


                counter = 0
                for list in Items:
                    if list == FirstUseItem:
                        break
                    counter+=1
                counter2 = 0
                for list in Items:
                    if list == SecondUseItem:
                        break
                    counter2+=1
                usagelist = [int(counter),int(counter2)]
                usagelist.sort()
                for list in USABLE:
                    if list[0]==usagelist[0] and list[1]==usagelist[1]:
                        list[2]()
                        return
                for list in NOTUSABLE:
                    if list[0]==usagelist[0] and list[1]==usagelist[1]:
                        print(list[2])
                        return
                print("You can't use these two items together")
                return    
                
            if answer == "2":
                print("Which item would you like to use", FirstUseItem[1] + " on?")
                x = 1
                for list in Items:
                    if list[0]== CurrentLocation:
                        print(str(x) + ".)", list[1])
                        x += 1
                unsureofanswer = 1
                while unsureofanswer == 1:
                    itemchoice = input()
                    while unsureofanswer == 1:
                        try:
                            val = int(itemchoice)
                        except ValueError:
                            print("Invalid Choice")
                            print("Which item would you like to choose?")
                            break
                        if int(itemchoice)>x or int(itemchoice)<1:
                            print("Invalid Choice")
                            print("Which item would you like to choose?")
                            break
                        unsureofanswer = 0
                while x >= 1:
                    if itemchoice == str(x):
                        counter = 0
                        for list in Items:
                            if list[0]== CurrentLocation:
                                counter += 1
                                if counter == x:
                                    SecondUseItem = list
                    x-=1
                counter = 0
                for list in Items:
                    if list == FirstUseItem:
                        break
                    counter+=1
                counter2 = 0
                for list in Items:
                    if list == SecondUseItem:
                        break
                    counter2+=1
                usagelist = [int(counter),int(counter2)]
                usagelist.sort()
                for list in USABLE:
                    if list[0]==usagelist[0] and list[1]==usagelist[1]:
                        list[2]()
                        return
                for list in NOTUSABLE:
                    if list[0]==usagelist[0] and list[1]==usagelist[1]:
                        print(list[2])
                        return
                print("You can't use these two items together")
                return
                    
            if answer == "3":
                return
        if choice == "4":
            return

def Talk():
    global CurrentLocation

    # Count NPCS at current location
        check = 0
    for list in NPCS:
        if list[0]==CurrentLocation:
            check += 1

    # In case of only one, initiate conversation        
    if check == 1:
        for list in NPCS:
            if list[0]==CurrentLocation:
                list[3]()
                return

    # In case of multiple, prompt player        
    if check >= 1:
        print("Whom do you want to talk to?")

        x = 1
        for list in NPCS:
            if list[0]==CurrentLocation:
                print(str(x) + ".)", list[1])
                x += 1

        unsureofanswer = 1
        while unsureofanswer == 1:
            which = input()
            while unsureofanswer == 1:
                try:
                    val = int(which)
                except ValueError:
                    print("Invalid Choice")
                    print("Whom do you want to talk to?")
                    break
                if int(which)>=x:
                    print("Invalid Choice")
                    print("Whom do you want to talk to?")
                    break
                unsureofanswer = 0
                
        if int(which)<=x:
            positionchecker=0
            for list in NPCs:
                if list[0]== CurrentLocation:
                    positionchecker+=1
                    if positionchecker == int(which):
                        list[3]()
                        return


    print("There is no one to talk to.")

    }
}
