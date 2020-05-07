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
        List<ShipBase> Ships { get; }
        List<ICoordinate> ShotSpaces { get; set; }

        // Methods
        bool IsAlive();
        void SetShips(List<ShipBase> shipList);
        bool GotShot(ICoordinate shotSpace);



    }
}
