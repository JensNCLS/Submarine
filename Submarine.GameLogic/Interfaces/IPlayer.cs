using Submarine.GameLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Interfaces
{
    public interface IPlayer
    {
        // Properties
        int PlayerId { get; }
        List<ShipBase> Ships { get; set; }
        List<ICoordinate> ShotSpaces { get; set; }

        // Methods
        bool IsAlive();
        bool GotShot(ICoordinate shotSpace);



    }
}
