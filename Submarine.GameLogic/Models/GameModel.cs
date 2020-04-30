using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Models.Base;
using Submarine.GameLogic.Models.Ships;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Submarine.GameLogic.Models
{
    public class GameModel : IGame
    {
        // Properties
        public string LobbyId { get; set; }
        public int GameId { get; private set; }
        public List<IPlayer> Players { get; set; }
        public IBattlefield Battlefield { get; set; }
        public int Turn { get; set; }
        public bool ShootLoopActive { get; set; }
        public IPlayer CurrentPlayer { get; set; }
        // Keep track of turns --> TurnHistoryModel --> TurnNumber + Player?
        // List with Players on who has the turn
        private int PlayerCount { get; set; }
        public List<IPlayer> PlayerOrder { get; private set; }




        // Constructor
        public GameModel()
        {
            GameId = 0;
            ShootLoopActive = false;
        }



        // Methods
        // Game loops
        public string NewGame(int amountOfPlayers)
        {
            // Set GameId and player list
            GameId++;
            Players = new List<IPlayer>();

            // Create Battlefield
            Battlefield = new BattlefieldModel(10, 10, amountOfPlayers);

            // #TEMP: Create Players
            for (int i = 0; i < amountOfPlayers; i++)
            {
                PlayerModel player = new PlayerModel(i);
                Players.Add(player);
            }

            // Give Players a location on the map
            Battlefield.SetPlayersOnBattlefield(Players);

            return "lol";
        }


        // Change turn
        public void StartGame()
        {
            ShootLoopActive = true;
        }


        public bool ShootProjectile(ICoordinate shotCoordinate)
        {
            // Check which player has been shot
            var playerId = Battlefield.CheckPlayerLocation(shotCoordinate);
            var shotPlayer = Players.Where(p => p.PlayerId == playerId).FirstOrDefault();

            // Send the shot to the correct player
            var hit = shotPlayer.GotShot(shotCoordinate);

            // Put it back in the List
            Players[Players.FindIndex(p => p.PlayerId == playerId)] = shotPlayer;

            // #TODO Give feedback to the player who shot
            return hit;
        }


        public void ChangeTurn()
        {
            // Check Game state
            if (CheckAliveStates(Players) != null)
            {
                // Go to GameOver State
            }
            else
            {
                Turn++;

            }


        }


        /// <summary>
        /// Checks if all players are still alive
        /// </summary>
        /// <param name="players">List of players</param>
        /// <returns>Returns null if all players are alive, returns IPlayer if someone died</returns>
        private IPlayer CheckAliveStates(List<IPlayer> players)
        {
            foreach (IPlayer player in players)
            {
                if (!player.IsAlive())
                {
                    ShootLoopActive = false;
                    return player; 
                }
                Debug.WriteLine("CheckAliveStates - Player " + player.PlayerId + " is alive.");
            }
            return null;
        }






        /// <summary>
        /// Creates a random player order
        /// </summary>
        /// <param name="players">List of players</param>
        /// <returns>Returns a list with the player order</returns>
        private List<IPlayer> CreatePlayerOrder(List<IPlayer> players)
        {
            List<IPlayer> playerOrder = players;
            // #TODO Rework this to make it random
            return playerOrder;
        }


        // Set Ships of player
        public void SetShipsOfPlayer(IPlayer player, List<ShipBase> ships)
        {
            player.Ships = ships;
        }

        public List<ShipBase> GetDebugShipSetP1()
        {
            List<ShipBase> ships = new List<ShipBase>();
            var ship1 = new FlexibleShipModel(new CoordinateModel(3, 3));
            ships.Add(ship1);
            return ships;
        }
        public List<ShipBase> GetDebugShipSetP2()
        {
            List<ShipBase> ships = new List<ShipBase>();
            var ship1 = new FlexibleShipModel(new CoordinateModel(3, 13));
            ships.Add(ship1);
            return ships;
        }

    }
}
