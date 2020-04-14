using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models
{
    class GameModel : IGame
    {
        // Properties
        public string LobbyId { get; set; }
        public List<IPlayer> Players { get; set; }
        public IBattlefield Battlefield { get; set; }



        // Constructor
        public GameModel()
        {

        }



        // Methods
        public string NewGame()
        {
            throw new NotImplementedException();
        }

        public bool ShootProjectile()
        {
            throw new NotImplementedException();
        }
    }
}
