using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Struct
{
    struct Blackjack
    {
        public int Cardpoint(int y)//checks how many points the card choosen is worth.
        {
            int[] points = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };//all but ace is there. since ace goes through a different process
            return points[y];
        }
        public string[,] Shuffle()//will give the game a new deck of cards.
        {
           string[,] shuffle = new string[4, 13]
        { {"Clubs 2", "Clubs 3", "Clubs 4", "Clubs 5", "Clubs 6", "Clubs 7", "Clubs 8", "Clubs 9", "Clubs 10", "Clubs Jack", "Clubs Queen", "Clubs King", "Clubs Ace"},
         {"Hearts 2","Hearts 3","Hearts 4","Hearts 5","Hearts 6","Hearts 7","Hearts 8","Hearts 9","Hearts 10","Hearts Jack","Hearts Queen","Hearts King","Hearts Ace" },
         {"Diamonds 2","Diamonds 3","Diamonds 4","Diamonds 5","Diamonds 6","Diamonds 7","Diamonds 8","Diamonds 9","Diamonds 10","Diamonds Jack","Diamonds Queen","Diamonds King","Diamonds Ace" },
         {"Spades 2","Spades 3","Spades 4","Spades 5","Spades 6","Spades 7","Spades 8","Spades 9","Spades 10","Spades Jack","Spades Queen","Spades King","Spades Ace" } };
            return shuffle;//will give out a fresh deck of cards.
        }
    }
    public class Player
    {
        Blackjack blackjack;
        public List<string> ownedcard = new List<string>();//the player's cards
        public int cardtotal;//how much the players have each when it comes to card value
        Random rnd = new Random();
        public void Reset()//reset the players entirely 
        {
            this.ownedcard.Clear();
            this.cardtotal = 0;
        }
        public string[,] Pickcard(string[,] cards)//Caluclations on what card the player's get
        {//cards is the ingame's avaliblecards
            int x;
            int y;
            bool nonnull = true;//used to stop it when a card is picked.
            while (nonnull)
            {
                x = rnd.Next(0, 4);
                y = rnd.Next(0, 13);
                if (cards[x,y] != "NULL")// cards[x,y] is what row of card's it's trying to pick, and checking if the card isn't NULL
                {
                    nonnull = false;//the card is not a NULL and can go through the system
                    this.ownedcard.Add(cards[x, y]);//adds the card to the player's collection of cards
                    cards[x, y] = "NULL";//replaces the card with a NULL  in the avaliblecards
                    if (y != 12)//12 is really an ACE.
                        this.cardtotal = this.cardtotal + blackjack.Cardpoint(y);
                    else
                    {
                        if (this.cardtotal <= 10)//An ACE is different. It can either be 1 or 11. It will be 11 if the player got below 10 in cardtotal
                            this.cardtotal = this.cardtotal + 11;
                        else
                            this.cardtotal = this.cardtotal + 1;//The ACE, if the player got over 10 in cardtotal. It will be turned into a 1 instead of 11
                    }
                }
            }
            return cards;//returns the cards to avaliblecards
        }
        public void Display()//used to show the info of a player
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string card in this.ownedcard)//shows all the cards a player got
            {
                Console.Write(card + "  ");
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\r\n" + this.cardtotal);//shows how much the card's total is
            Console.ResetColor();
        }
        public bool Checkbust()//used to check if a player is bust
        {
            bool bust;
            if (this.cardtotal > 21)//if it's above 21 the player has lost, so it will return bust true.
                bust = true;
            else
                bust = false;//it's below 21, so nothing will change.
            return bust;
        }
    }
}
