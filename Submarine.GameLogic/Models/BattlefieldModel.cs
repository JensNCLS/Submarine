using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Submarine.GameLogic.Models
{
    class BattlefieldModel : IBattlefield
    {
        // Properties
        public int BattlefieldWidth { get; }
        public int BattlefieldHeight { get; }
        public List<IPlayerLocation> PlayerPositions { get; private set; }



        // Constructor
        public BattlefieldModel(int width, int height)
        {
            BattlefieldWidth = width;
            BattlefieldHeight = height;
        }



        // Methods
        public bool SetPlayersOnBattlefield(List<IPlayer> players)
        {
            // Count how many players
            throw new NotImplementedException();
        }


        public int CheckPlayerLocation(ICoordinate coordinate)
        {
            throw new NotImplementedException();
        }


    }
}
