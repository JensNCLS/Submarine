using Submarine.Terminal.Helpers;
using System;
using System.Threading.Tasks;
using Submarine.GameLogic.Models;

namespace Submarine.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Properties
            TextHelper TextHelper = new TextHelper();
            GameModel Game = new GameModel();



            // Crappy implementation to test the Submarine game
            Console.Title = "Submarine - Terminal edition";
            TextHelper.ShowText("Hello", 10000);
            TextHelper.ShowText("Ready to play a super crappy game of Battleship?");
            TextHelper.ShowText("WARNING: This version of Submarine runs directly of the GameLogic, and is intended for playtesting the GameLogic only.");
            TextHelper.ShowText("No connections to the normal Submarine.Core or ServiceBus will be made");
            TextHelper.ShowText("");
            TextHelper.ShowText("Press any key to continue...");
            Console.ReadKey();
            TextHelper.ShowText("", 0);



            // Create a new game
            TextHelper.ShowText("New Game created...");


            Console.ReadKey();


            // Set ships


            // Shoot loops



            // Game Over state







        }



        // Rediculous loops




    }
}
