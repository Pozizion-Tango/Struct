
using System;

namespace Struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pc pc = new Pc();
            Player player = new Player();
            Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("----------------"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue; Console.Write(" BLACK "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("----------------"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta; Console.Write("----------------"); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue; Console.Write(" JACK  "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("----------------"); Console.ResetColor();
            Blackjack bj = new Blackjack();

            bj.cards = pc.Shuffle();
        }
    }
}
