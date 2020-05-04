using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                return false;
            }
            else { return true; }
        }

        /// <summary>
        /// Handles the shot coordinate with the ship
        /// </summary>
        /// <param name="shotCoordinate">Shot coordinate</param>
        public bool GotShot(ICoordinate shotCoordinate)
        {
            var occupiedCoordinate = OccupiedSpaces.Where(c => c.X == shotCoordinate.X && c.Y == shotCoordinate.Y).FirstOrDefault();
            var previouslyShot = DamagedSpaces.Where(c => c.X == shotCoordinate.X && c.Y == shotCoordinate.Y).FirstOrDefault();

            if (occupiedCoordinate != null)
            {
                if (previouslyShot == null)
                {
                    Debug.WriteLine("Ship got shot on " + shotCoordinate.X + ", " + shotCoordinate.Y);
                    DamagedSpaces.Add(shotCoordinate);
                    return true;
                }
                else
                {
                    // This space has already been damaged
                    return false;
                }
            }
            else { return false; }
        }
    }
}
