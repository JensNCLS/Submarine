using Submarine.GameLogic.Helpers;
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
        //private int PlayerCount { get; set; }
        public List<IPlayer> PlayerOrder { get; private set; }

        private ShotValidationHelper _shotValidator;



        // Constructor
        public GameModel()
        {
            GameId = 0;
            ShootLoopActive = false;
            _shotValidator = new ShotValidationHelper();
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
        /// <summary>
        /// Validates the shot
        /// </summary>
        /// <param name="shotCoordinate">The coordinate you want to shoot at</param>
        /// <returns>Returns the results so an invalid shot can be handled if nessesary</returns>
        public ValidateShotResult ValidateShot(ICoordinate shotCoordinate)
        {
            var result = _shotValidator.ValidateShot(shotCoordinate, CurrentPlayer, Battlefield);
            return result;
        }



        // #3
        /// <summary>
        /// Shoots at the given coordinate
        /// </summary>
        /// <param name="shotCoordinate">The coordinate you want to shoot at</param>
        /// <param name="validation">Enter the results of ValidateShot here. Will give an exception if the shot is not valid!</param>
        /// <returns>Returns 'True' on a hit and 'False' on a miss</returns>
        public bool ShootProjectile(ICoordinate shotCoordinate, ValidateShotResult validation)
        {
            if (validation == ValidateShotResult.Valid)
            {
                // Check which player has been shot
                // Validate the shot again to be sure someone didn't just doctor the result
                var result = _shotValidator.ValidateShot(shotCoordinate, CurrentPlayer, Battlefield);
                Debug.WriteLine("GameModel - ShootProjectile - Shot Validation - Shot was " + result.ToString());

                if (result == ValidateShotResult.Valid)
                {
                    // Send the shot to the correct player
                    var playerId = Battlefield.CheckPlayerLocation(shotCoordinate);
                    var playerIndex = Players.FindIndex(p => p.PlayerId == playerId);
                    var hit = Players[playerIndex].GotShot(shotCoordinate);

                    // Add shot to list of shot spaces
                    var cpIndex = Players.FindIndex(p => p.PlayerId == CurrentPlayer.PlayerId);
                    Players[cpIndex].ShotSpaces.Add(shotCoordinate);

                    return hit;
                }
                else
                {
                    throw new Exception("GameModel - ShootProjectile - Botched validation given - ERROR");
                }
            }
            else
            {
                throw new Exception("GameModel - ShootProjectile - Shot not validated or given illegal move - ERROR");
            }
        }


        // Check for another shot --> afhandelen door front-end


        // #4
        /// <summary>
        /// Ends the current turn and checks for the Game Over-state
        /// </summary>
        public void EndTurn()
        {
            var deadPlayer = CheckAliveStates(Players);
            if (deadPlayer != null)
            {
                Debug.WriteLine("GameModel - EndTurn - Game Over stated. ");
                Debug.WriteLine("Player " + deadPlayer.PlayerId + " died");
            }
            else
            {
                ChangeTurn();
            }
        }


        // #5
        /// <summary>
        /// Ends the turn of the current player and changes to the next one
        /// </summary>
        /// <returns>Return IPlayer model that will be the next lucky player :)</returns>
        public IPlayer ChangeTurn()
        {
            IPlayer nextPlayer;
                if (CurrentPlayer == null)
                { CurrentPlayer = PlayerOrder[0]; }
                else
                {
                Debug.WriteLine("GameModel - ChangeTurn - Ending of Turn for Player " + CurrentPlayer.PlayerId);

                // #TODO Improve this to be done via alogrythm instead of hardcoded
                if (CurrentPlayer == PlayerOrder[0])
                    { CurrentPlayer = PlayerOrder[1]; }
                    else if (CurrentPlayer == PlayerOrder[1])
                    { CurrentPlayer = PlayerOrder[0]; }
                }
                Turn++;
                Debug.WriteLine("GameModel - ChangeTurn - Start of Turn for Player " + CurrentPlayer.PlayerId);

            // #TODO: Change this that the CurrentPlayer will be based on the NextPlayer
            nextPlayer = CurrentPlayer;

            return nextPlayer;
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






    }
}
