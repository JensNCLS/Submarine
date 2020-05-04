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


        // #1
        /// <summary>
        /// Starts the Battle (requires ships to be set for all players)
        /// </summary>
        public void StartBattle()
        {
            // #TODO: Check if the players actually have their ships set
            PlayerOrder = CreatePlayerOrder(Players);

            ShootLoopActive = true;

            ChangeTurn();
        }


        // #2
        public bool ShootProjectile(ICoordinate shotCoordinate)
        {
            // Check which player has been shot
            var playerId = Battlefield.CheckPlayerLocation(shotCoordinate);
            CheckOnSelfShooting(shotCoordinate, CurrentPlayer.PlayerId);

            // Send the shot to the correct player
            var playerIndex = Players.FindIndex(p => p.PlayerId == playerId);
            var hit = Players[playerIndex].GotShot(shotCoordinate);

            // #TODO Give feedback to the player who shot
            return hit;
        }


        // #3 Check for another shot


        // #4
        /// <summary>
        /// Ends the current turn and checks for the Game Over-state
        /// </summary>
        public void EndTurn()
        {
            if (CheckAliveStates(Players) != null)
            {
                Debug.WriteLine("GameModel - EndTurn - Game Over stated ");
            }
        }


        // #5
        /// <summary>
        /// Ends the turn of the current player and changes to the next one
        /// </summary>
        public void ChangeTurn()
        {
                if (CurrentPlayer == null)
                { CurrentPlayer = PlayerOrder[0]; }
                else
                {
                Debug.WriteLine("GameModel - ChangeTurn - Ending of Turn for PlayerID " + CurrentPlayer.PlayerId);

                // #TODO Improve this to be done via alogrythm instead of hardcoded
                if (CurrentPlayer == PlayerOrder[0])
                    { CurrentPlayer = PlayerOrder[1]; }
                    else if (CurrentPlayer == PlayerOrder[1])
                    { CurrentPlayer = PlayerOrder[0]; }
                }
                Turn++;
                Debug.WriteLine("GameModel - ChangeTurn - Start of Turn for PlayerID " + CurrentPlayer.PlayerId);
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


        public bool CheckIfShotIsLegal(ICoordinate coordinate, int CurrentPlayerId)
        {
            // Change this to enum

            throw new NotImplementedException();
        }


        private bool CheckOnShootingSameSpaceTwice()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Checks if the player the current player shot at isn't themself
        /// </summary>
        /// <param name="coordinate">the coordinate the player shot at</param>
        /// <param name="CurrentPlayerId">The player who shot the shot</param>
        /// <returns>Returns true if the player didn't shoot themself, false if they shot themself</returns>
        private bool CheckOnSelfShooting(ICoordinate coordinate, int CurrentPlayerId)
        {
            var playerId = Battlefield.CheckPlayerLocation(coordinate);
            if  (playerId == CurrentPlayerId)
            {
                return false;
            }
            return true;
        }

    }
}
