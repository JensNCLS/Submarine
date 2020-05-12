using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models.Ships
{
    public class SmallShipModel : ShipBase
    {
        // Properties
        /// <summary>
        /// Shows the allowed amount of spaces for this shipunit
        /// </summary>
        public new static readonly int AmountOfAllowedSpaced = 2;



        // Constructor
        /// <summary>
        /// A small size ship spanning across 2 coordinates
        /// </summary>
        /// <param name="coordinate1">Coordinate 1</param>
        /// <param name="coordinate2">Coordinate 2</param>
        public SmallShipModel(ICoordinate coordinate1, ICoordinate coordinate2)
        {
            OccupiedSpaces = new List<ICoordinate>() { coordinate1, coordinate2 };
            DamagedSpaces = new List<ICoordinate>();
        }
    }
}
