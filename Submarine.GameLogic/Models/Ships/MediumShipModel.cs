using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models.Ships
{
    public class MediumShipModel : ShipBase
    {
        // Properties
        /// <summary>
        /// Shows the allowed amount of spaces for this shipunit
        /// </summary>
        public new static readonly int AmountOfAllowedSpaced = 3;



        // Constructor
        /// <summary>
        /// A madium size ship spanning across 3 coordinates
        /// </summary>
        /// <param name="coordinate1">Coordinate 1</param>
        /// <param name="coordinate2">Coordinate 2</param>
        /// <param name="coordinate3">Coordinate 3</param>
        public MediumShipModel(ICoordinate coordinate1, ICoordinate coordinate2, ICoordinate coordinate3)
        {
            OccupiedSpaces = new List<ICoordinate>() { coordinate1, coordinate2, coordinate3 };
            DamagedSpaces = new List<ICoordinate>();
        }
    }
}
