using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models.Ships
{
    public class ExtraLargeShipModel : ShipBase
    {
        // Properties
        /// <summary>
        /// Shows the allowed amount of spaces for this shipunit
        /// </summary>
        public new static readonly int AmountOfAllowedSpaced = 5;



        // Constructor
        /// <summary>
        /// An extra large size ship spanning across 5 coordinates
        /// </summary>
        /// <param name="coordinate1">Coordinate 1</param>
        /// <param name="coordinate2">Coordinate 2</param>
        /// <param name="coordinate3">Coordinate 3</param>
        /// <param name="coordinate4">Coordinate 4</param>
        /// <param name="coordinate5">Coordinate 5</param>
        public ExtraLargeShipModel(ICoordinate coordinate1, ICoordinate coordinate2, ICoordinate coordinate3, ICoordinate coordinate4, ICoordinate coordinate5)
        {
            OccupiedSpaces = new List<ICoordinate>() { coordinate1, coordinate2, coordinate3, coordinate4, coordinate5 };
            DamagedSpaces = new List<ICoordinate>();
        }
    }
}
