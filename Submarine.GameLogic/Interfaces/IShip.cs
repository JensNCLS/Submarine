using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Interfaces
{
    interface IShip
    {
        // Properties
        /// <summary>
        /// The coordinates the ship occupies
        /// </summary>
        List<ICoordinate> OccupiedSpaces { get; set; }
        /// <summary>
        /// The coordinates the other players have destroyed
        /// </summary>
        List<ICoordinate> DamagedSpaces { get; set; }



        // Methods
        /// <summary>
        /// Checks if the ship is still alive
        /// </summary>
        bool IsAlive();
        /// <summary>
        /// Handles the shot coordinate with the ship
        /// </summary>
        /// <param name="shotCoordinate">Shot coordinate</param>
        bool GotShot(ICoordinate shotCoordinate);
    }
}
