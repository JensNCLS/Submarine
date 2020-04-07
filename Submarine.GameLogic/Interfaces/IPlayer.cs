using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Interfaces
{
    interface IPlayer
    {
        // Properties
        int PlayerId { get; set; }
        List<IShip> Ships { get; set; }
        List<ICoordinate> ShotSpaces { get; set; }

        // Methods
        bool GotShot(ICoordinate shotSpace);

    }
}
