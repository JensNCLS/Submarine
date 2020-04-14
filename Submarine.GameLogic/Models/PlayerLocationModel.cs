using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models
{
    class PlayerLocationModel : IPlayerLocation
    {
        // Properties
        public int PlayerId { get; set; }
        /// <summary>
        /// The first (lower-left) coordinate assinged for the player
        /// </summary>
        public ICoordinate StartCoordinate { get; set; }
        /// <summary>
        /// The last (upper-right) coordinate assinged for the player
        /// </summary>
        public ICoordinate EndCoordinate { get; set; }
    }
}
