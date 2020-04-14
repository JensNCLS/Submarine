using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models
{
    class CoordinateModel : ICoordinate
    {
        // Properties
        public int X { get; set; }
        public int Y { get; set; }



        // Constructor
        public CoordinateModel(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
