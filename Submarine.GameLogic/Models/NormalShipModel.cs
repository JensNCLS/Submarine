using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models
{
    public class NormalShipModel : ShipBase
    {
        // Properties



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

    }
}
