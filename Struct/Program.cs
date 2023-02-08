
using System;

namespace Struct
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool stop = false;//bool here is used to stop the entire program when the user wishes
            Player playeruser = new Player();//creates 2 players, one being you. Other being the "computer"
            Player playerbot = new Player();
            Blackjack blackjack = new Blackjack();//blackjack is made to keep all cards in if needed.
            while (!stop)
            {
                Console.Clear();//clears last round's off the screen.
                Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("----------------"); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue; Console.Write(" BLACK "); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("----------------"); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("----------------"); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue; Console.Write(" JACK  "); Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("----------------"); Console.ResetColor();
                Console.WriteLine("\r\n\r\n1:Play\r\n\r\n2:Quit");//tells the user what they can do
                string choice = Console.ReadLine();//choice is used to select between the If/elses
                if(choice =="1")
                {
                    Console.Clear();
                    bool reset = false;//this bool is used a lot in the program, to either stop the round, or end it if one loses
                    while (!reset)
                    {   
                        string[,] avaliblecards = blackjack.Shuffle();//a new set of cards are created from blackjack. (avaliblecards) will slowly run out when new cards are picked.
                        playeruser.Reset();//if they have any scores or cards they will be removed
                        playerbot.Reset();
                        avaliblecards = playeruser.Pickcard(avaliblecards);//the player get's 2 cards to start with, as per rules in blackjack.
                        avaliblecards = playeruser.Pickcard(avaliblecards);
                        while (!reset)
                        {
                            playeruser.Display();//will show off what cards the player have and their total count
                            Console.WriteLine("1: Call For Another Card\r\n2:Play Cards\r\n0:Reset");
                            choice = Console.ReadLine();//choice is again used to select what they player now wanna do.
                            if (choice == "1")//for a new card
                            {
                                Console.Clear();
                                avaliblecards = playeruser.Pickcard(avaliblecards);//gives player another card
                                if (playeruser.Checkbust())//Checks if the player is over 21
                                {
                                    playeruser.Display();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You Lost! Press Any Key To Continue");//the player was over 21 and went bust. Games stops
                                    Console.ResetColor();
                                    Console.ReadKey();
                                    reset = true;//Player got bust, so the game ends by turning reset to True
                                }
                            }
                            else if (choice == "2")//the player have choosen to let to bot play, and will not be allowed to pick more cards
                            {
                                Console.Clear();
                                Console.WriteLine("Bot's Turn\r\n");
                                while (!reset)
                                {    
                                    avaliblecards = playerbot.Pickcard(avaliblecards);//the bot picks up their first card
                                    playerbot.Display();//shows what card the bot now owns.
                                    if (playerbot.Checkbust())//checks if the bot is bust
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Bot Lost, User win! Press Any Key To Continue");//if the bot loses. the user wins
                                        Console.ResetColor();
                                        Console.WriteLine("\r\nUser's cards");
                                        playeruser.Display();
                                        Console.ReadKey();
                                        reset = true;//game stops now that the user won.
                                    }
                                    else if (playerbot.cardtotal > playeruser.cardtotal && playerbot.cardtotal < 21)//checks if the bot won over the user
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("You Lost! Press Any Key To Continue");//bot had less then 21 but more then the user.
                                        Console.ResetColor();
                                        Console.WriteLine("\r\nUser's cards");
                                        playeruser.Display();
                                        Console.ReadKey();
                                        reset = true;//user lost. games resets
                                    }
                                }
                            }
                            else if (choice == "0")//user choose to reset the game. Don't really know why i added that as an option?
                            {
                                reset = true;
                            }
                            else//something was wrong in what the user picked. and is warned about so.
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid option. Press Anything To Try Again");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                    }
                }
                else if (choice == "2")//The user have quit the game, and it will now close.
                {
                    stop = true;
                }
                else//user typed in something that was not the option, and is warned.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option. Press Anything To Try Again");
                    Console.ReadKey();
                }
            }
        }
    }
}
