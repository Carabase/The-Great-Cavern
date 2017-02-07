using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ItemManager
    {
        public List<Item> Initialize()
        {
            Item I0 = new Item(-1, "A Stone", "It seems to be a rather ordinary gray stone about the size of your fist.", "y");
            Item I1 = new Item(2, "An Unlit Torch", "A torch made of a piece of cloth wrapped around a wooden stick. It is currently unlit.", "y");
            Item I2 = new Item(-1, "A Lit Torch", "Since you stuck the torch in a burning bush, it is now lit.", "y");
            Item I3 = new Item(-1, "A Half-Eaten Apple", "Someone has taken a bite out of it", "y");
            Item I4 = new Item(1, "A Blue Stone", "A shiny blue stone. Could it be a saph... No, it isn't.", "y");
            Item I5 = new Item(5, "A Burning Bush", "because you would burn yourself.", "n");
            Item I6 = new Item(7, "The Snicker Snacker Blade", "A mighty sword with a serrated blade and a jade skull adorning its handle", "y");
            Item I7 = new Item(-100, "A Worn Letter", "My Dear Friend," + "\n" + "I wish this letter were to be a joyous one, but I fear it will have to be a" + "\n" + "carrier of sad news. My father has finally succumbed to his affliction of gout. He passed away last evening. We all knew it was coming, but I can barely believe" + "\n" + "he's gone. The funeral is to be held two weeks from now,and I want you to be there. Make haste towards Castle Cluny. I know you and my father didn't always see eye to eye, but he would've wanted you to come. Henrietta will be pleased to see you as well. Good fortunes upon you and I do hope you come." + "\n" + "Your friend," + "\n" + "            Charles" + "\n" + "P.S. Avoid the old mines. I know they're the quickest way through the mountains but recently they've been taken over b..." + "\n" + "(The bottom part of the letter has been drenched by what appears to be wine and is now unreadable.)", "y");

            List<Item> Items = new List<Item>(new Item[] { I0, I1, I2, I3, I4, I5, I6, I7 });
            return Items;
        }
        // Item Combinations

        // 1

        //Turns an unlit Torch into a lit one
        public void TorchLighting(List<Item> Items)
        {
            Items[1].Location = -1;
            Items[2].Location = -100;
            Console.WriteLine("You manage to light the torch by sticking it into the burning bush.");
        }

        def LetterBurning(): #Burns the Letter
            Items[7][0]=-1
            print("Congratulations! You've tossed your letter in a fire and watched as it burnt to a crisp. I hope you read it first.")


        // Item Usability

        IU0 = [1,5, TorchLighting]
        IU1 = [5,7, LetterBurning]

        USABLE = [IU0, IU1]

        INU0 = [4,7,"You rub the blue stone on the letter accomplishing very little in the process"]
        NOTUSABLE = [INU0]

    }
}
