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
        public List<ShipBase> shipList = new List<ShipBase>();

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

            //for (int r = 0; r < viewGrid.Length; r++)
            //{
            //    for (int c = 0; c < viewGrid[r].Length; c++)
            //    {
            //        viewGrid[r][c][0] = tempGrid[r][]
            //        //for (int i = 0; i < viewGrid[r][c].Length; i++)
            //        //{
            //        //    viewGrid[r][c][i] = tempGrid[r][c + i];
            //        //    string test = tempGrid[r][c + i].ToString();
            //        //}
            //    }
            //}
            string test = tempGrid[0][0].ToString();
            string test1 = tempGrid[0][1].ToString();
            string test2 = tempGrid[0][2].ToString();
            string test3 = tempGrid[0][3].ToString();

            List<ICoordinate> coSmall = new List<ICoordinate>();
            List<ICoordinate> coMedium = new List<ICoordinate>();
            List<ICoordinate> coMediumSub = new List<ICoordinate>();
            List<ICoordinate> coLarge = new List<ICoordinate>();
            List<ICoordinate> coExtraLarge = new List<ICoordinate>();

            for (int r = 0; r < viewGrid.Length; r++)
            {
                for (int c = 0; c < viewGrid[r].Length; c++)
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
