using Submarine.GameLogic.Models;
using Submarine.GameLogic.Models.Base;
using Submarine.GameLogic.Models.Ships;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Helpers
{
    /// <summary>
    /// This class is for providing demo/debug test data
    /// </summary>
    public class DebugDataHelper
    {
        public List<ShipBase> GetDebugShipSetP1()
        {
            List<ShipBase> ships = new List<ShipBase>();
            var ship1 = new FlexibleShipModel(new CoordinateModel(3, 3));
            ships.Add(ship1);
            return ships;
        }
        public List<ShipBase> GetDebugShipSetP2()
        {
            List<ShipBase> ships = new List<ShipBase>();
            var ship1 = new FlexibleShipModel(new CoordinateModel(3, 13));
            ships.Add(ship1);
            return ships;
        }
    }
}
