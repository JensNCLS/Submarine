using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Submarine.GameLogic.Models.Base;

namespace Submarine.Web.Models
{
    public class ConvertGridModel
    {
        public string[][][] viewGrid;
        public List<ShipBase> shipList;

        public void ConvertGrid(IEnumerable<string> grid)
        {
            foreach (var row in grid)
            {
                string[] gridRow = row.Split(",");
            }
        }
    }
}
