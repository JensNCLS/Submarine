using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Interfaces
{
    interface IShip
    {
        // Properties
        List<ICoordinate> OccupiedSpaces { get; set; }
        List<ICoordinate> DamagedSpaces { get; set; }



        // Methods
        bool IsAlive();
        bool GotShot(ICoordinate shotCoordinate);
    }
}
