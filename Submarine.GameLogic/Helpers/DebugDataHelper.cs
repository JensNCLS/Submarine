using Submarine.GameLogic.Models;
using Submarine.GameLogic.Models.Base;
using Submarine.GameLogic.Models.Ships;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var ship2 = new FlexibleShipModel(new CoordinateModel(4, 4));
            ships.Add(ship1);
            ships.Add(ship2);
            Debug.WriteLine("DebugDataHelper - P1 - Ship set at " + ship1.OccupiedSpaces[0].X.ToString() + ", " + ship1.OccupiedSpaces[0].Y.ToString());
            Debug.WriteLine("DebugDataHelper - P1 - Ship set at " + ship2.OccupiedSpaces[0].X.ToString() + ", " + ship2.OccupiedSpaces[0].Y.ToString());
            return ships;
        }
        public List<ShipBase> GetDebugShipSetP2()
        {
            List<ShipBase> ships = new List<ShipBase>();
            var ship1 = new FlexibleShipModel(new CoordinateModel(3, 13));
            Debug.WriteLine("DebugDataHelper - P2 - Ship set at " + ship1.OccupiedSpaces[0].X.ToString() + ", " + ship1.OccupiedSpaces[0].Y.ToString());
            ships.Add(ship1);
            return ships;
        }
    }
}
