using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models.Base
{
    abstract public class ShipBase
    {
        // Properties
        /// <summary>
        /// Override this per ship!
        /// </summary>
        public static readonly int AmountOfAllowedSpaced = 0;

        /// <summary>
        /// The coordinates the ship occupies
        /// </summary>
        public List<ICoordinate> OccupiedSpaces { get; set; }

        /// <summary>
        /// The coordinates the other players have destroyed
        /// </summary>
        public List<ICoordinate> DamagedSpaces { get; set; }




        // Methods
        /// <summary>
        /// Checks if the ship is still alive
        /// </summary>
        public bool IsAlive()
        {
            if (DamagedSpaces.Count >= OccupiedSpaces.Count)
            {
                // #TODO Add in a check if all places have actually been shot
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Handles the shot coordinate with the ship
        /// </summary>
        /// <param name="shotCoordinate">Shot coordinate</param>
        public bool GotShot(ICoordinate shotCoordinate)
        {
            if (OccupiedSpaces.Contains(shotCoordinate) && !DamagedSpaces.Contains(shotCoordinate))
            {
                DamagedSpaces.Add(shotCoordinate);
                return true;
            }
            else { return false; }
        }
    }
}
