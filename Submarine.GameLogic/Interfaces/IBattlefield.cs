using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Interfaces
{
    interface IBattlefield
    {
        // Properties
        /// <summary>
        /// Battfield Width (X-axis)
        /// </summary>
        int BattlefieldWidth { get; }
        /// <summary>
        /// Battfield Height (Y-axis)
        /// </summary>
        int BattlefieldHeight { get; }
        /// <summary>
        /// List with all the Player Positions
        /// </summary>
        List<IPlayerLocation> PlayerPositions { get; }



        // Methods
        bool SetPlayersOnBattlefield(List<IPlayer> players);
        /// <summary>
        /// Checks which player is located on the given coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>Returns PlayerId of the player in that position. Will return null if no player is on that location</returns>
        int CheckPlayerLocation(ICoordinate coordinate);
    }
}
