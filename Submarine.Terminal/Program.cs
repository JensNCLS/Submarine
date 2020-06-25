using Submarine.Terminal.Helpers;
using System;
using System.Threading.Tasks;
using Submarine.GameLogic.Models;
using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Helpers;

namespace Submarine.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Properties
            TextHelper TextHelper = new TextHelper();
            GameModel Game = new GameModel();
            DebugDataHelper debugDataHelper = new DebugDataHelper();



            // Implementation to test the Submarine game
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
            Game.NewGame(2);
            TextHelper.ShowText("New Game created for two players...");
            Console.ReadKey();
            TextHelper.ShowText("");



            // Set ships
            var debugShipsP1 = debugDataHelper.GetDebugShipSetP1();
            var debugShipsP2 = debugDataHelper.GetDebugShipSetP2();
            Game.SetShipsOfPlayer(Game.Players[0], debugShipsP1);
            Game.SetShipsOfPlayer(Game.Players[1], debugShipsP2);
            // #END OF HARDWIRED DEBUG


            TextHelper.ShowText("Ships have been set...");
            Console.ReadKey();



            // Shoot loops
            Game.StartBattle();
            while (Game.ShootLoopActive)
            {
                TextHelper.ShowText("Player " + Game.CurrentPlayer.PlayerId + " turn");
                TextHelper.ShowText("Shoot X coordinate: ");
                string xCo = Console.ReadLine();
                TextHelper.ShowText("Shoot Y coordinate: ");
                string yCo = Console.ReadLine();

                TextHelper.ShowText("Shooting at(" + xCo + ", " + yCo + ")...");
                var shotCoordinate = new CoordinateModel(Convert.ToInt32(xCo), Convert.ToInt32(yCo));

                // Shoot and handle the shot
                // Validate the shot
                var validatationResult = Game.ValidateShot(shotCoordinate);
                var isHit = Game.ShootProjectile(shotCoordinate, validatationResult);
                TextHelper.ShowText("Did the player hit something? " + isHit.ToString());

                Game.EndTurn();
                Game.ChangeTurn();
            }



            // Game Over state


            TextHelper.ShowText("Game over");
            string x = Console.ReadLine();
        }
    }
}
