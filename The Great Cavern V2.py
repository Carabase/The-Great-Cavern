#                                                                                        THE GREAT CAVERN - CODE
#                                                                                            By Paul Pfenning

import time
import sys
import math

# Global Variables

alive = 1
PreviousLocation = -1
CurrentLocation = 0
knightcounter = 0

Globals = [alive,PreviousLocation,CurrentLocation,knightcounter]

# Look Descriptions

Look_Description_0 = ""
Look_Description_1 = "You look around and on the floor you discover:"
Look_Description_2 = "You look around and spot a wooden chest half buried in the mud. Upon opening it you find:"
Look_Description_3 = ""
Look_Description_4 = ""
Look_Description_5 = "You quickly notice smoke rising up in the distance. Upon approaching you see a:"
Look_Description_6 = "You once again notice the wooden door to the north."
Look_Description_7 = "Stached away behind a pile of crates you find:"
Look_Description_8 = ""

# Descriptions

Description_0 ="You stand at the entrance of a great cavern, that tunnels westwards into the mountainside. You can see a forest off east in the distance."
Description_1 ="You are in a corridor leading down into the murky depths of the cavern, light is growing dim. The cave entrance is back to the east and in the west darkness awaits."                    
Description_2 ="You have reached the edge of the forest and are now standing atop a grassy knoll. You can see the cave entrance to the west, as well an arid plain to the north."
Description_3 ="You are lost in the wild undergrowth of the forest. It is eerily silent, you can't even hear the birds chirp."
Description_4 ="Now that you have a lit torch, you can see what was once darkness is now two paths, one headed north and the other south."
Description_5 ="You are standing in an arid plain. Fields of barley stretch on for miles and miles. The grassy knoll lies to the south far in the distance."
Description_6 ="The northern path goes on upwards into the mountain. After walking for several meters, you arrive at a wooden door set into the stone face."
Description_7 ="You are now standing in what appears to be a storage room of sorts."
Description_8 ="The southern path winds on downwards for a ways, until you come to what looks like the entrance to a mine shaft. A terrified looking man is leaning against the cavern walls. Back north lies the fork and the mines continue on southward."

# Locations

#     N     E     S     W     Descriptions  Events          Look_Descriptions     Times Looked
    
L0 = [-995 ,2    ,-995 ,1    ,Description_0,"NoEvent"      ,Look_Description_0,       0]
L1 = [-996 ,0    ,-996 ,4    ,Description_1,"NoEvent"      ,Look_Description_1,       0]
L2 = [5    ,3    ,-998 ,0    ,Description_2,"NoEvent"      ,Look_Description_2,       0]
L3 = [-1000,-999 ,-998 ,2    ,Description_3,"KnightEvent"  ,Look_Description_3,       0]
L4 = [6    ,1    ,8    ,-997 ,Description_4,"DarknessEvent",Look_Description_4,       0]
L5 = [-1000,-999 ,2    ,-997 ,Description_5,"NoEvent"      ,Look_Description_5,       0]
L6 = [-994 ,-999 ,4    ,-997 ,Description_6,"DoorEvent"    ,Look_Description_6,       0]
L7 = [-996 ,-996 ,6    ,-997 ,Description_7,"NoEvent"      ,Look_Description_7,       0]
L8 = [4    ,-996 ,-996 ,-997 ,Description_8,"NoEvent"      ,Look_Description_8,       0]

Locations = [L0,L1,L2,L3,L4,L5,L6,L7,L8]                

# Items

I0 = [-1, "A Stone", "It seems to be a rather ordinary gray stone about the size of your fist.", "y"]
I1 = [2, "An Unlit Torch", "A torch made of a piece of cloth wrapped around a wooden stick. It is currently unlit.", "y"]
I2 = [-1, "A Lit Torch", "Since you stuck the torch in a burning bush, it is now lit.", "y"]
I3 = [-1, "A Half-Eaten Apple", "Someone has taken a bite out of it", "y"]
I4 = [1, "A Blue Stone","A shiny blue stone. Could it be a saph... No, it isn't.", "y"]
I5 = [5, "A Burning Bush","because you would burn yourself.", "n"]
I6 = [7, "The Snicker Snacker Blade", "A mighty sword with a serrated blade and a jade skull adorning its handle","y"]
I7 = [-100, "A Worn Letter", "My Dear Friend," +"\n"+"I wish this letter were to be a joyous one, but I fear it will have to be a"+"\n"+"carrier of sad news. My father has finally succumbed to his affliction of gout. He passed away last evening. We all knew it was coming, but I can barely believe"+"\n"+"he's gone. The funeral is to be held two weeks from now,and I want you to be there. Make haste towards Castle Cluny. I know you and my father didn't always see eye to eye, but he would've wanted you to come. Henrietta will be pleased to see you as well. Good fortunes upon you and I do hope you come."+"\n"+ "Your friend,"+"\n"+"            Charles"+"\n"+"P.S. Avoid the old mines. I know they're the quickest way through the mountains but recently they've been taken over b..."+"\n"+"(The bottom part of the letter has been drenched by what appears to be wine and is now unreadable.)","y"]

Items = [I0,I1,I2,I3,I4,I5,I6,I7]

# Item Combinations

# 1

def TorchLighting(): #Turns an unlit Torch into a lit one
    Items[1][0]=-1
    Items[2][0]=-100
    print ("You manage to light the torch by sticking it into the burning bush.")
def LetterBurning(): #Burns the Letter
    Items[7][0]=-1
    print ("Congratulations! You've tossed your letter in a fire and watched as it burnt to a crisp. I hope you read it first.")


# Item Usability

IU0 = [1,5,TorchLighting]
IU1 = [5,7,LetterBurning]

USABLE = [IU0,IU1]

INU0 = [4,7,"You rub the blue stone on the letter accomplishing very little in the process"]
NOTUSABLE = [INU0]



#NPC Behaviour

def Miner_Behaviour():
    global CurrentLocation
    if NPC0[0] == CurrentLocation and NPC0[4] == 0:
        NPC0[3]()
    

#NPC Dialogue

def Miner_Dialogue():
    
    if NPC0[4] == 0:
        print("The man leaning against the wall gets up in startled shock at seeing you.")
        TreeParser(MinerTree,NPC0)
        NPC0[4] = 1
    else:
        print("You talk to the old man, but he's given up on you.")
        print(NPC0[1]+":")
        print("Do what you will.")

#Dialogue Trees

Miner0 = ["Hey, you there! What are you doing here? .........", "1.) I've got a wedding to get to and no time to dawdle.", "2.) Buzz off, old man!", 1, -1]
Miner1 = ["I wouldn't reccomend going this way. Vile creatures have moved into these mines", "1.) Thanks for the advice but I must be on my way.", -1]

MinerTree = [Miner0, Miner1]

def TreeParser(Tree,NPC):
    currentBranch = Tree[0]
    talking = 1
    while talking == 1:
        print(NPC[1]+":")
        print(currentBranch[0])
        options = 0
        for x in range(1, int((len(currentBranch)+1)/2)):
            print(currentBranch[x])
            options += 1           
        unsureofanswer = 1
        while unsureofanswer == 1:
            which = input()
            while unsureofanswer == 1:
                try:
                    val = int(which)
                except ValueError:
                    print ("Invalid Choice")
                    break
                if int(which)<=0 or int(which)> 2:
                    print ("Invalid Choice")
                    break
                unsureofanswer = 0
                       
        if currentBranch[int(which)+options] == -1:
            return
        currentBranch = Tree[currentBranch[int(which)+options]]
        
           
# NPCs

NPC0 = [8,"Old Miner",Miner_Behaviour,Miner_Dialogue,0]

NPCS = [NPC0]       

#  Events

# 1
def knightencounter(counter):
    global knightcounter
    global alive
    global CurrentLocation
    global PreviousLocation
    if knightcounter == 0:    
        print ("Quietly at first, but then louder and louder you hear the pattering sound of hooves.")
        print ("A group of armoured and weaponed knights burst through the thicket and start circling round you on their horses.")
        print ("Their leader approaches you and says,'You are trespassing on sacred ground. Leave and never return or you won't live to regret it'.")
        answering = 1
        while answering == 1:
            ans = input("What is your decision? Leave or Stay ")
            if ans == 'Leave':
                print ("'You have made the right decision, but I warn you never to return here.'")
                knightcounter = 1
                CurrentLocation = PreviousLocation
                return
            if ans == 'Stay':
                print ("'I am sorry it has come to this,' says the knight as he brings his mace smashing down on your skull.")
                print ("Your lifeless bodys sags and crumples to the ground.")
                alive = 0
                return
            if ans != 'Stay' or 'Leave':
                print ("Invalid Answer")
    if knightcounter == 1:
        print ("But that silence is not kept for long as the knights appear once more.")
        print ("'You did not heed our warning and now you must pay the price', says the knight as he decapitates you with one fell swoop.")
        print ("Your head flies off your shoulders and lands on the ground with a thunk, your body following close behind.")
        alive = 0
        return

# 2
def DarknessEvent():
    global CurrentLocation
    global PreviousLocation

    if Items[2][0]== -100:
        return
    if Items[2][0]!= -100:
        print ("The light continues fading until you find yourself in pitch blackness.")
        answering = 1
        x = 0
        while answering == 1:
            if x >= 1:
                print ("You find yourself in pitch blackness.")
            var = input("Where do you go? ")
            if var == 'n':
                print ("You stumble forward through the darkness in the direction you believe to be north.")
                x += 1
                continue
            if var == 'e':
                print ("After stumbling eastwards for a way, you see light off in the distance.")
                print ("Eventually you reach a cave entrance, one that seems awfully familiar.")
                print ("You quickly realize you're right back where you started.")
                CurrentLocation = PreviousLocation
                return 
              
            if var == 's':
                print ("You stumble forward through the darkness in the direction you believe to be south.")
                x += 1
                continue
            if var == 'w':
                print ("You stumble forward through the darkness in the direction you believe to be west.")
                x += 1
                continue
            if var != 'n' or 's' or 'e' or 'w':
                print ("Invalid Answer")

# 3
def DoorEvent():
    global CurrentLocation
    global PreviousLocation
    answering = 1    
    while answering == 1:
        var = input("Do you want to try to open the door? (Y/N)" )
        if var == 'Y':
            print ("You try to open the door. Luckily for you it wasn't locked and swings open.")
            Locations[6][0] = 7
            return
        if var == 'N':
            answering = 0
        else:
            print ("Invalid Choice")



# Saving
def save():
    save = open("C:\\Users\\Public\\Documents\\savefile.txt","w")
    save.write("Global Variables"+"\n")
    save.write("PreviousLocation"+"\n")
    save.write(str(PreviousLocation)+"\n")
    save.write("knightcounter"+"\n")
    save.write(str(knightcounter)+"\n")
    save.write("CurrentLocation"+"\n")
    save.write(str(CurrentLocation)+"\n")
    save.write("Locations Viewed"+"\n")
    global Locations
    for list in Locations:
        save.write (str(list[7])+"\n")
    save.write("Item Position"+"\n")
    global Items
    for list in Items:
        save.write (str(list[0])+"\n")
    save.write("NPC State"+"\n")
    global NPCS
    for list in NPCS:
        save.write (str(list[0])+"\n")
        save.write (str(list[4])+"\n")
    print ("You have succesfully saved.")
    save.close
           
#Actions

def Help():
    print ("This is the list of keyboard controls.")
    print ("      You can move by pressing 'n', 'e', 's', and 'w'.")
    print ("      You can look around for items using 'l'.")
    print ("      You can pick up items once you have looked around using 'p'.")
    print ("      You can view your inventory using 'i'.")
    print ("      You can talk to an NPC using 't'.")
    print ("      You can save the game by using 'z'.")
    print ("      You can exit the game by typing 'quit' or 'exit'.")

def Moving(var):
    global CurrentLocation

    if var == 'n':
        var = 0
    if var == 'e':
        var = 1
    if var == 's':
        var = 2
    if var == 'w':
        var = 3

    if Locations[CurrentLocation][var] >= 0:
            CurrentLocation = Locations[CurrentLocation][var]
            return True    

    #Case for not being able to leave to the north
    if Locations[CurrentLocation][var] == -1000:
        print ("You can't go north")
    #Case for not being able to leave to the east
    if Locations[CurrentLocation][var] == -999:
        print ("You can't go east")
    #Case for not being able to leave to the south
    if Locations[CurrentLocation][var] == -998:
        print ("You can't go south")
    #Case for not being able to leave to the west
    if Locations[CurrentLocation][var] == -997:
        print ("You can't go west")
    #Case for there being cave wall in your way   
    if Locations[CurrentLocation][var] == -996:
        print ("Unsurprisingly, you fail to walk through the cave wall.")
        print ("Instead, you bump your head. Ouch!")
    #Case for being at the Cave Entrance
    if Locations[CurrentLocation][var] == -995:
        print ("You briefly consider trying to find a way around the mountains before realizing that the detour would take weeks.")
    #Case for there being a door in the way
    if Locations[CurrentLocation][var] == -994:
        print ("As much as you would like to head that direction, you have not yet mastered the art of walking through doors.")

def Look():
    global CurrentLocation
    check = 0
    Locations[CurrentLocation][7] += 1
    for list in Items:
        if list[0]==CurrentLocation:
            check = 1
            break
    if check ==1:
        print (Locations[CurrentLocation][6])
        for list in Items:
            if list[0]==CurrentLocation:
                print (list[1])
        return
    if  Locations[CurrentLocation][7] == 10:
        print ("Be careful, don't strain your eyes. You still don't find anything.")
    elif  Locations[CurrentLocation][7] == 25:
        print ("If anything had changed, you would have noticed by now.")
    else:
        print ("You don't find anything.")

def PickUp():
    global CurrentLocation
    
    if Locations[CurrentLocation][7] < 1:
            print ("You haven't looked to see if there is anything to pick up.")
            return
        
    CheckForItemInLocation = 0
    for list in Items:
        if list[0]==CurrentLocation:
            CheckForItemInLocation = 1
            
    if CheckForItemInLocation == 1:
        print ("What do you want to pick up?")
        print ("1.) Everything")
        print ("2.) Nothing")
        x = 2
        for list in Items:
            if list[0]==CurrentLocation:
                x += 1
                print (str(x) + ".)", list[1])
                
        unsureofanswer = 1
        while unsureofanswer == 1:
            which = input()
            while unsureofanswer == 1:
                try:
                    val = int(which)
                except ValueError:
                    print ("Invalid Choice")
                    print ("What do you want to pick up?")
                    break
                if int(which)>x:
                    print ("Invalid Choice")
                    print ("What do you want to pick up?")
                    break
                if int(which)<=0:
                    print ("Invalid Choice")
                    print ("What do you want to pick up?")
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
                print ("You weren't able to pick up anything.")    
            if counter > 0 and counter2 > 0:
                print ("You were only able to pick up some of the things.")
            if counter == 0 and counter2 > 0:
                print ("You pick up everything.")  
            return
        if which == "2":
            print ("You pick up nothing.")
            return
        if int(which)<=x:
                counter = 0
                positionchecker=0
                for list in Items:
                    if list[0]== CurrentLocation and counter==0:
                        positionchecker+=1
                        if positionchecker == int(which)-2 and list[3]=="y" :
                            list[0] = -100
                            print ("You pick up:")
                            print (list[1])
                            counter+=1
                            break
                        if positionchecker == int(which)-2 and list[3]=="n" :
                            print ("You can't pick it up " + list[2])
                            counter+=1
                            break
                return        
    print ("There is nothing here for you to pick up.")

def Inventory():
    
    print ("Your inventory contains:")
    
    check = 0
    for list in Items:
        if list[0]==-100:
            check = 1
    if check!= 1:
        print ("Absolutely Nothing!")
        return
    
    if check == 1:
        for list in Items:
            if list[0]==-100:
                print (list[1])
        print ("What do you want to do?")
        print ("1.) Examine an Item Closer")
        print ("2.) Drop an Item")
        print ("3.) Use an Item")
        print ("4.) Exit Inventory")
        
        unsureofanswer = 1
        while unsureofanswer == 1:
            choice = input()
            while unsureofanswer == 1:
                try:
                    val = int(choice)
                except ValueError:
                    print ("Invalid Choice")
                    print ("What do you want to do?")
                    break
                if int(choice)>4 or int(choice)<1:
                    print ("Invalid Choice")
                    print ("What do you want to do?")
                    break
                unsureofanswer = 0

        #Examine an Item
        if choice == "1":
            print ("Which item would you like to examine?")
            x = 1
            for list in Items:
                if list[0]==-100:
                    print (str(x) + ".)", list[1])
                    x += 1
            
            unsureofanswer = 1
            while unsureofanswer == 1:
                itemchoice = input()
                while unsureofanswer == 1:
                    try:
                        val = int(itemchoice)
                    except ValueError:
                        print ("Invalid Choice")
                        print ("Which item would you like to examine?")
                        break
                    if int(itemchoice)>3 or int(itemchoice)<1:
                        print ("Invalid Choice")
                        print ("Which item would you like to examine?")
                        break
                    unsureofanswer = 0      
            
            while x >= 1:
                if itemchoice == str(x):
                    counter = 0
                    for list in Items:
                        if list[0]==-100:
                            counter += 1
                            if counter == x:
                                print ("You examine:", list[1])
                                print (list[2])
                                break
                x -= 1
            return        

        #Drop an Item    
        if choice == "2":
            print ("Which item(s) do you want to drop?")
            print ("1.) All of them")
            print ("2.) None")
            x =3
            for list in Items:
                if list[0]==-100:
                    print (str(x) + ".)", list[1])
                    x += 1
            unsureofanswer = 1
            while unsureofanswer == 1:
                which = input()
                while unsureofanswer == 1:
                    try:
                        val = int(which)
                    except ValueError:
                        print ("Invalid Choice")
                        print ("Which item(s) do you want to drop?")
                        break
                    if int(which)>=x:
                        print ("Invalid Choice")
                        print ("Which item(s) do you want to drop?")
                        break
                    unsureofanswer = 0

            #Drop all        
            if which == "1":
                print ("You drop all of them.")
                for list in Items:
                    if list[0]== -100:
                        list[0] = CurrentLocation      
                return

            #Drop None
            if which == "2":
                print ("You drop none.")
                return

            #Drop Specific Item
            if int(which)<=x:
                while x > 2:
                    if which == str(x):
                        print ("You drop:")
                        counter = 0
                        for list in Items:
                            if list[0]==-100:
                                counter += 1
                                if counter == x-2:
                                    list[0] = CurrentLocation
                                    print (list[1])
                                    break
                    x -= 1
                return

        #Use an Item    
        if choice == "3":
            print ("Which item would you like to use?")
            x = 1
            for list in Items:
                if list[0]==-100:
                    print (str(x) + ".)", list[1])
                    x += 1
            
            unsureofanswer = 1
            while unsureofanswer == 1:
                itemchoice = input()
                while unsureofanswer == 1:
                    try:
                        val = int(itemchoice)
                    except ValueError:
                        print ("Invalid Choice")
                        print ("Which item would you like to use?")
                        break
                    if int(itemchoice)>x or int(itemchoice)<1:
                        print ("Invalid Choice")
                        print ("Which item would you like to use?")
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
                
            print ("Do you want to use this item with:")
            
            for list in Items:
                DoYouNotHaveItems = 0
                if list[0]== -100 and list != FirstUseItem:
                    print ("1.) Another item in your inventory?")
                    DoYouNotHaveItems = 0
                    break
                else:
                    DoYouNotHaveItems = 1
            if DoYouNotHaveItems == 1:
                print ("1.) You have no other items in your inventory.")

            for list in Items:
                IsThereAnItemInTheEnvironment = 0
                if list[0]== CurrentLocation:
                    print ("2.) Something in the environment?")
                    IsThereAnItemInTheEnvironment = 1
                    break
                else:
                    IsThereAnItemInTheEnvironment = 0
           
            if IsThereAnItemInTheEnvironment == 0:
                print ("2.) There are no items in the environment.")
                
            print ("3.) Nothing.")

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
                     print ("Invalid Choice")

            #Use the item with another item in the inventory   
            if answer == "1":
                print ("Which item would you like to use with", FirstUseItem[1] + "?")
                x = 1
                for list in Items:
                    if list[0]==-100 and list != FirstUseItem:
                        print (str(x) + ".)", list[1])
                        x += 1
                unsureofanswer = 1
                while unsureofanswer == 1:
                    itemchoice = input()
                    while unsureofanswer == 1:
                        try:
                            val = int(itemchoice)
                        except ValueError:
                            print ("Invalid Choice")
                            print ("Which item would you like to choose?")
                            break
                        if int(itemchoice)>x or int(itemchoice)<1:
                            print ("Invalid Choice")
                            print ("Which item would you like to choose?")
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
                        print (list[2])
                        return
                print("You can't use these two items together")
                return    
                
            if answer == "2":
                print ("Which item would you like to use", FirstUseItem[1] + " on?")
                x = 1
                for list in Items:
                    if list[0]== CurrentLocation:
                        print (str(x) + ".)", list[1])
                        x += 1
                unsureofanswer = 1
                while unsureofanswer == 1:
                    itemchoice = input()
                    while unsureofanswer == 1:
                        try:
                            val = int(itemchoice)
                        except ValueError:
                            print ("Invalid Choice")
                            print ("Which item would you like to choose?")
                            break
                        if int(itemchoice)>x or int(itemchoice)<1:
                            print ("Invalid Choice")
                            print ("Which item would you like to choose?")
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
        print ("Whom do you want to talk to?")

        x = 1
        for list in NPCS:
            if list[0]==CurrentLocation:
                print (str(x) + ".)", list[1])
                x += 1

        unsureofanswer = 1
        while unsureofanswer == 1:
            which = input()
            while unsureofanswer == 1:
                try:
                    val = int(which)
                except ValueError:
                    print ("Invalid Choice")
                    print ("Whom do you want to talk to?")
                    break
                if int(which)>=x:
                    print ("Invalid Choice")
                    print ("Whom do you want to talk to?")
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

def Execute(Location):
    global PreviousLocation
    global CurrentLocation
    
    #Events that overide Location Description
    
    if Locations[Location][5]== "DarknessEvent":
        DarknessEvent()
        if CurrentLocation == PreviousLocation:
            return
        
    #Give Location Description
    print (Locations[Location][4])

    #Perform NPC Behaviour
    for list in NPCS:
        list[2]()

    #Events that follow Location Description
    
    if Locations[Location][5]== "KnightEvent":
        knightencounter(knightcounter)
        return
    if Locations[Location][5]== "DoorEvent":
        DoorEvent()

    #Update Location 
    PreviousLocation = CurrentLocation

    #Start Input Loop
    answering = 1
    locationMarker = 0
    while answering == 1:
        if locationMarker >= 1:
            print (Locations[Location][4])
        var = input("What do you do? ")

        if var == '?':
            Help()
            locationMarker += 1
            print("")
            continue
        
        if var == 'n' or var == 's' or var == 'e' or var == 'w':
            if Moving(var)== True:
                print("")
                return
            else:
                locationMarker += 1
                print("")
                continue
        
        if var == 'l':
            print("")
            Look()
            locationMarker += 1
            print("")
            continue

        if var == 'p':
            print("")
            PickUp()
            locationMarker += 1
            print("")
            continue
        
        if var == 'i':
            print("")
            Inventory()
            locationMarker += 1
            print("")
            continue
        
        if var == 'z':
            save()
            locationMarker += 1
            print("")
            continue

        if var == 't':
            Talk()
            locationMarker += 1
            print("")
            continue
        
        if var == 'quit' or var == 'exit':
            print ("Thanks for playing.")
            time.sleep(3)
            sys.exit()
                        
        else:
            print ("Invalid Answer")
            print("")
            locationMarker += 1
        
# Introduction        
print ("Welcome to THE GREAT CAVERN")
print ("Thanks for playing.")
print ("Press '?' for instructions")

# Loading
try:
    open("C:\\Users\\Public\\Documents\\savefile.txt","r")
    print ("You are loading a previous save.")
    save = open("C:\\Users\\Public\\Documents\\savefile.txt","r")
    save.readline() # Global Variables:
    save.readline() # PreviousLocation
    PreviousLocation = int(save.readline()) # Update PreviousLocation
    save.readline() # knightcounter
    knightcounter = int(save.readline()) # Update knightcounter    
    save.readline() # CurrentLocation
    CurrentLocation = int(save.readline()) # Update CurrentLocation

    save.readline() # Locations Viewed
    checker = 0
    while checker <= len(Locations)-1:
        Locations[checker][7]= int(save.readline())
        checker += 1

    save.readline() # Item Position
    checker2 = 0
    while checker2 <= len(Items)-1:
        Items[checker2][0]= int(save.readline())
        checker2 += 1

    save.readline() # NPC State
    checker3 = 0
    while checker3 <= len(NPCS)-1:
        NPCS[checker3][0]= int(save.readline())
        NPCS[checker3][4]= int(save.readline())
        checker3 += 1
       
except IOError:
    print ("You are starting a new game.")

while alive == 1:
    Execute(CurrentLocation)
print ("GAME OVER")
sys.exit()
