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
        private List<string[]> tempGrid = new List<string[]>();
        private List<List<string[]>> viewGrid = new List<List<string[]>>();
        public List<ShipBase> shipList = new List<ShipBase>();

        public void ConvertGrid(IEnumerable<string> grid)
        {
            foreach (var row in grid)
            {
                string[] gridRow = row.Split(",");
                tempGrid.Add(gridRow);
            }

            foreach (var row in tempGrid)
            {
                List<string[]> rowList = new List<string[]>(); 
                for (int i = 0; i < row.Length; i+=2)
                {
                    string[] cell = new[] {row[i], row[i + 1]};
                    rowList.Add(cell);
                }
                viewGrid.Add(rowList);
            }

            List<ICoordinate> coSmall = new List<ICoordinate>();
            List<ICoordinate> coMedium = new List<ICoordinate>();
            List<ICoordinate> coMediumSub = new List<ICoordinate>();
            List<ICoordinate> coLarge = new List<ICoordinate>();
            List<ICoordinate> coExtraLarge = new List<ICoordinate>();

            for (int r = 0; r < viewGrid.Count; r++)
            {
                for (int c = 0; c < viewGrid[r].Count; c++)
                {
                    if (viewGrid[r][c][1] == "small")
                    {
                        coSmall.Add(new CoordinateModel(r, c));
                    }
                    if (viewGrid[r][c][1] == "medium")
                    {
                        coMedium.Add(new CoordinateModel(r, c));
                    }
                    if (viewGrid[r][c][1] == "submedium")
                    {
                        coMediumSub.Add(new CoordinateModel(r, c));
                    }
                    if (viewGrid[r][c][1] == "large")
                    {
                        coLarge.Add(new CoordinateModel(r, c));
                    }
                    if (viewGrid[r][c][1] == "extraLarge")
                    {
                        coExtraLarge.Add(new CoordinateModel(r, c));
                    }
                }
            }

            SmallShipModel smallShip = new SmallShipModel(coSmall[0], coSmall[1]);
            shipList.Add(smallShip);
            MediumShipModel mediumShip = new MediumShipModel(coMedium[0], coMedium[1], coMedium[2]);
            shipList.Add(mediumShip);
            MediumShipModel mediumSub = new MediumShipModel(coMediumSub[0], coMediumSub[1], coMediumSub[2]);
            shipList.Add(mediumSub);
            LargeShipModel largeShip = new LargeShipModel(coLarge[0], coLarge[1], coLarge[2], coLarge[3]);
            shipList.Add(largeShip);
            ExtraLargeShipModel extraLargeShip = new ExtraLargeShipModel(coExtraLarge[0], coExtraLarge[1], coExtraLarge[2], coExtraLarge[3], coExtraLarge[4]);
            shipList.Add(extraLargeShip);
            int t = shipList.Count;
        }
    }
}
