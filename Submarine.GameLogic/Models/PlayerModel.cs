using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models
{
    class PlayerModel : IPlayer
    {
        // Properties
        public int PlayerId { get; set; }
        public List<IShip> Ships { get; set; }
        public List<ICoordinate> ShotSpaces { get; set; }



        // Constructor
        public PlayerModel()
        {

        }



        // Methods
        public bool GotShot(ICoordinate shotCoordinate)
        {
            // 1 - Check if a ship is occuping the shot space
            var ship = CheckIfShipGotShot(shotCoordinate);
            if (ship != null)
            {
                // 2 - Handle the damage on the ship
                var isHit = ship.GotShot(shotCoordinate);
                return isHit;
                
                // #TODO --> 3 - Check if ship is still alive
            }
            else { return false; }


            throw new NotImplementedException();
        }

        private IShip CheckIfShipGotShot(ICoordinate shotCoordinate)
        {
            throw new NotImplementedException();
            return null;
        }
    }
}
