using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Interfaces
{
    interface IPlayerLocation
    {
        // Properties
        int PlayerId { get; set; }
        /// <summary>
        /// The first (lower-left) coordinate assinged for the player
        /// </summary>
        ICoordinate StartCoordinate { get; set; }
        /// <summary>
        /// The last (upper-right) coordinate assinged for the player
        /// </summary>
        ICoordinate EndCoordinate { get; set; }
    }
}
