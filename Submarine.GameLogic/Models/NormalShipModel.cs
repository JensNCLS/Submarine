using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models
{
    public class NormalShipModel : IShip
    {
        // Properties
        /// <summary>
        /// The coordinates the ship occupies
        /// </summary>
        public List<ICoordinate> OccupiedSpaces { get; set; }
        /// <summary>
        /// The coordinates the other players have destroyed
        /// </summary>
        public List<ICoordinate> DamagedSpaces { get; set; }



        //Constructor
        /// <summary>
        /// Create a new Normal Ship Model (multiple spaces)
        /// </summary>
        /// <param name="occupiedCoordinates">List with multiple coordinates</param>
        public NormalShipModel(List<ICoordinate> occupiedCoordinates)
        {
            OccupiedSpaces = occupiedCoordinates;
            DamagedSpaces = new List<ICoordinate>();
        }

        /// <summary>
        /// Create a new Normal Ship Model (single space)
        /// </summary>
        /// <param name="occupiedCoordinate">A single coordinate the ship occupies</param>
        public NormalShipModel(ICoordinate occupiedCoordinate)
        {
            OccupiedSpaces = new List<ICoordinate>() { occupiedCoordinate };
            DamagedSpaces = new List<ICoordinate>();
        }



        // Methods
        /// <summary>
        /// Checks if the ship is still alive
        /// </summary>
        /// <returns>Returns 'true' for alive and 'false' for destroyed</returns>
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
        /// <returns>Returns 'true' for a hit and 'false' for a miss</returns>
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
