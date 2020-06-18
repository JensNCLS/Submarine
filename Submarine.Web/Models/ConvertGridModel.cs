using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Models;
using Submarine.GameLogic.Models.Base;
using Submarine.GameLogic.Models.Ships;

namespace Submarine.Web.Models
{
    public class ConvertGridModel
    {
        List<string[]> tempGrid = new List<string[]>();
        public string[][][] viewGrid = new string[10][][];
        public List<ShipBase> shipList;

        public void ConvertGrid(IEnumerable<string> grid)
        {
            foreach (var row in grid)
            {
                for (int r = 0; r < viewGrid.Length; r++)
                {
                    viewGrid[r] = new string[10][];
                    for (int c = 0; c < viewGrid[r].Length; c++)
                    {
                        viewGrid[r][c] = new string[2];
                    }
                }

                string[] gridRow = row.Split(",");
                tempGrid.Add(gridRow);
            }

            for (int r = 0; r < viewGrid.Length; r++)
            {
                for (int c = 0; c < viewGrid[r].Length; c++)
                {
                    for (int i = 0; i < viewGrid[r][c].Length; i++)
                    {
                        viewGrid[r][c][i] = tempGrid[r][c + i];
                    }
                }
            }
            
            for (int r = 0; r < viewGrid.Length; r++)
            {
                for (int c = 0; c < viewGrid[r].Length; c++)
                {
                    if (viewGrid[r][c][0] == "clicked")
                    {
                        if (viewGrid[r][c][1] == "small")
                        {
                            SmallShipModel smallShip = new SmallShipModel(new CoordinateModel(r, c), );
                        }
                    }
                }
            }
        }
    }
}
