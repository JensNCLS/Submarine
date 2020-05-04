using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Submarine.GameLogic.Models
{
    public class BattlefieldModel : IBattlefield
    {
        // Properties
        public int BattlefieldWidth { get; }
        public int BattlefieldHeight { get; }
        public List<IPlayerLocation> PlayerPositions { get; private set; }
        private List<IPlayerLocation> _draftPlayerPositions { get; set; }



        // Constructor
        /// <summary>
        /// Creates a new Battlefield
        /// </summary>
        /// <param name="width">Width of the Battlefield for a single player</param>
        /// <param name="height">Height of the Battlefield for a single player</param>
        /// <param name="amountOfPlayers">The amount of players that will play the game</param>
        public BattlefieldModel(int width, int height, int amountOfPlayers)
        {
            // Get the player startpositions
            _draftPlayerPositions = DraftBattlefieldPositions(width, height, amountOfPlayers);

            // Get max range of battlefield
            CoordinateModel outmostCoordinate = GetMaxBattlefieldWidthAndHeight(_draftPlayerPositions);
            BattlefieldWidth = outmostCoordinate.X;
            BattlefieldHeight = outmostCoordinate.Y;
        }



        // Methods
        /// <summary>
        /// Sets players to a position on the battlefield
        /// </summary>
        /// <param name="players">List with IPlayer models</param>
        /// <returns>Returns bool indicating setting the players was successful</returns>
        public bool SetPlayersOnBattlefield(List<IPlayer> players)
        {
            // #TODO: Let this method handle only the adding of PlayerLocations to the PlayerPositions
            List<IPlayerLocation> playerLocations = new List<IPlayerLocation>();

            foreach (IPlayer player in players)
            {
                if (_draftPlayerPositions.Count != 0)
                {
                    var playerLocation = _draftPlayerPositions[0];
                    Debug.WriteLine("BattlefieldModel - SetPlayersOnBattlefield - playerLocation, StartCoordinates:" + playerLocation.StartCoordinate.X + ", " + playerLocation.StartCoordinate.Y);
                    Debug.WriteLine("BattlefieldModel - SetPlayersOnBattlefield - playerLocation, EndCoordinates:" + playerLocation.EndCoordinate.X + ", " + playerLocation.EndCoordinate.Y);
                    playerLocation.PlayerId = player.PlayerId;
                    Debug.WriteLine("BattlefieldModel - SetPlayersOnBattlefield - playerLocation, PlayerId:" + playerLocation.PlayerId);

                    playerLocations.Add(playerLocation);
                    _draftPlayerPositions.RemoveAt(0);
                }
                else
                {
                    throw new Exception("ERROR - BattlefieldModel - SetPlayersOnBattlefield - Not enough drafted player positions for all players");
                }
            }

            PlayerPositions = playerLocations;
            return true;
        }

        /// <summary>
        /// Checks which PlayerId is on the given coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>Returns the PlayerId of the given coordinate</returns>
        public int CheckPlayerLocation(ICoordinate coordinate)
        {
            int playerId = -1;
            int Xinp = coordinate.X;
            int Yinp = coordinate.Y;

            foreach (IPlayerLocation playerLocation in PlayerPositions)
            {
                // Check welke coordinaten binnen deze dingen vallen
                
                if (Xinp >= playerLocation.StartCoordinate.X  && Xinp <= playerLocation.EndCoordinate.X)
                {
                    if (Yinp >= playerLocation.StartCoordinate.Y && Yinp <= playerLocation.EndCoordinate.Y)
                    {
                        playerId = playerLocation.PlayerId;
                    }
                }
            }

            if (playerId == -1)
            {
                throw new Exception("BattlefieldModel - Shot was out of bounds");
            }

            Debug.WriteLine("BattlefieldModel - CheckPlayerLocation - Battlearea of Player " + playerId + " got shot");
            return playerId;
        }

        /// <summary>
        /// Creates a list with draft positions for the battlefield
        /// </summary>
        /// <param name="width">Width of the Battlefield for a single player</param>
        /// <param name="height">Height of the Battlefield for a single player</param>
        /// <param name="amountOfPlayers">The amount of players that will play the game</param>
        /// <returns>Retruns a list of Player Locations used for the draft positions</returns>
        private List<IPlayerLocation> DraftBattlefieldPositions(int width, int height, int amountOfPlayers)
        {
            List<IPlayerLocation> playerLocations = new List<IPlayerLocation>();
            int widthEndPosition = width--;
            int heightEndPosition = height--;

            // Hacky af, but it should work x) 
            switch (amountOfPlayers)
            {
                case 2:
                    {
                        // Player 1
                        var player1 = new PlayerLocationModel(new CoordinateModel(0, 0), new CoordinateModel(widthEndPosition, heightEndPosition));
                        playerLocations.Add(player1);
                        // Player 2
                        var player2 = new PlayerLocationModel(new CoordinateModel(0, height), new CoordinateModel(widthEndPosition, (height + heightEndPosition)));
                        playerLocations.Add(player2);

                        break;
                    }
                case 3:
                    {
                        // #TODO: Think of something to make this work
                        throw new Exception("BattlefieldModel - GetMaxBattlefieldWidthAndHeight: Unexpected amount of players");
                    }
                case 4:
                    {
                        // Player 1
                        var player1 = new PlayerLocationModel(new CoordinateModel(0, 0), new CoordinateModel(widthEndPosition, heightEndPosition));
                        playerLocations.Add(player1);
                        // Player 2
                        var player2 = new PlayerLocationModel(new CoordinateModel(0, height), new CoordinateModel(widthEndPosition, (height + heightEndPosition)));
                        playerLocations.Add(player2);
                        // Player 3
                        var player3 = new PlayerLocationModel(new CoordinateModel(width, 0), new CoordinateModel((width + widthEndPosition), heightEndPosition));
                        playerLocations.Add(player3);
                        // Player 4
                        var player4 = new PlayerLocationModel(new CoordinateModel(width, height), new CoordinateModel((width + widthEndPosition), (height + heightEndPosition)));
                        playerLocations.Add(player4);

                        break;
                    }
                default:
                    {
                        throw new Exception("BattlefieldModel - GetMaxBattlefieldWidthAndHeight: Unexpected amount of players");
                    }
            }

            return playerLocations;
        }

        /// <summary>
        /// Gets the max width and max height of the battlefield
        /// </summary>
        /// <param name="listOfPlayers">A list with Player Locations</param>
        /// <returns>Returns a CoordinateModel with the outmost coordinate</returns>
        private CoordinateModel GetMaxBattlefieldWidthAndHeight(List<IPlayerLocation> listOfPlayers)
        {
            int maxWidth = 0;
            int maxHeight = 0;

            foreach (IPlayerLocation player in listOfPlayers)
            {
                if (player.EndCoordinate.X > maxWidth)
                { maxWidth = player.EndCoordinate.X; }
                if (player.EndCoordinate.Y > maxHeight)
                { maxHeight = player.EndCoordinate.Y; }
            }

            CoordinateModel maxCoordinates = new CoordinateModel(maxWidth, maxHeight);
            return maxCoordinates;
        }
    }
}
