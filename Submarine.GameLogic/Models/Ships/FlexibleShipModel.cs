using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models.Ships
{
    class FlexibleShipModel : ShipBase
    {
        // Properties
        /// <summary>
        /// Shows the allowed amount of spaces for this shipunit
        /// </summary>
        public new static readonly int AmountOfAllowedSpaced = 99;




        //Constructor
        /// <summary>
        /// Create a new Flexible Ship (multiple spaces)
        /// </summary>
        /// <param name="occupiedCoordinates">List with multiple coordinates</param>
        public FlexibleShipModel(List<ICoordinate> occupiedCoordinates)
        {
            OccupiedSpaces = occupiedCoordinates;
            DamagedSpaces = new List<ICoordinate>();
        }

        /// <summary>
        /// Create a new Flexible Ship (single space)
        /// </summary>
        /// <param name="occupiedCoordinate">A single coordinate the ship occupies</param>
        public FlexibleShipModel(ICoordinate occupiedCoordinate)
        {
            OccupiedSpaces = new List<ICoordinate>() { occupiedCoordinate };
            DamagedSpaces = new List<ICoordinate>();
        }
    }
}
