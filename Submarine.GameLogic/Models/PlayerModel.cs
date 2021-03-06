﻿using Submarine.GameLogic.Interfaces;
using Submarine.GameLogic.Models.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Submarine.GameLogic.Models
{
    public class PlayerModel : IPlayer
    {
        // Properties
        public int PlayerId { get; private set; }
        public List<ShipBase> Ships { get; private set; }
        /// <summary>
        /// Keeps track of the spaces the coordinates the player (self) shot during the game
        /// </summary>
        public List<ICoordinate> ShotSpaces { get; set; }



        // Constructor
        public PlayerModel(int playerId)
        {
            PlayerId = playerId;
            Ships = new List<ShipBase>();
            ShotSpaces = new List<ICoordinate>();
        }

        // Methods
        /// <summary>
        /// Checks if the player still has ships that are alive
        /// </summary>
        /// <returns>Returns a bool indicating if the player still has living ships</returns>
        public bool IsAlive()
        {
            int deadShips = 0;
            foreach (ShipBase ship in Ships)
            {
                if (!ship.IsAlive())
                {
                    deadShips++;
                }
            }

            if (deadShips >= Ships.Count)
            {
                Debug.WriteLine("PlayerModel - IsAlive - Player " + PlayerId + " has lost all ships. - GAME OVER P" + PlayerId);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Handles a shot the other player made at this player
        /// </summary>
        /// <param name="shotCoordinate">The coordinate the other player shot at</param>
        /// <returns>Returns 'True' for a hit and 'False' for a miss</returns>
        public bool GotShot(ICoordinate shotCoordinate)
        {
            // 1 - Check if a ship is occuping the shot space
            var ship = CheckIfShipGotShot(shotCoordinate);
            if (ship != null)
            {
                // 2 - Handle the damage on the ship
                var shipIndex = Ships.FindIndex(s => s.OccupiedSpaces == ship.OccupiedSpaces);
                var isHit = Ships[shipIndex].GotShot(shotCoordinate);
                return isHit;
                
                // #TODO --> 3 - Check if ship is still alive --> Will be handled by the GameModel by checking the PlayerModel-IsAlive()
            }
            else { return false; }
        }

        /// <summary>
        /// Gets a list of all damaged spaces of the player
        /// </summary>
        /// <returns>Returns a List with all the damaged spaces</returns>
        public List<ICoordinate> GetListOfAllDamagedSpaces()
        {
            var list = new List<ICoordinate>();

            foreach (var ship in Ships)
            {
                foreach (var coordinate in ship.DamagedSpaces)
                { list.Add(coordinate); }
            }

            return list;
        }

        /// <summary>
        /// Sets the Ships for a player
        /// </summary>
        /// <param name="ships">List of ships the player has set</param>
        public void SetShips(List<ShipBase> shipList)
        {
            Ships = shipList;
        }

        /// <summary>
        /// Checks if one of the players ships occupies the shot space
        /// </summary>
        /// <param name="shotCoordinate"></param>
        /// <returns>Returns Ship model of shot ship if hit, returns null if shot was a miss</returns>
        private ShipBase CheckIfShipGotShot(ICoordinate shotCoordinate)
        {
            foreach (ShipBase ship in Ships)
            {
                foreach (ICoordinate coordinate in ship.OccupiedSpaces)
                {
                    // #TODO Check if the coordinate has already been damaged
                    if (coordinate.X == shotCoordinate.X && coordinate.Y == shotCoordinate.Y)
                    {
                        return ship;
                    }
                }
            }

            // If we reached the code here then no ship is on the shot coordinate, so let's send back a null.
            return null;
        }

        ///// <summary>
        ///// Add a Coordinate to the list that keeps track of coordinated the player shot at
        ///// </summary>
        ///// <param name="shot"></param>
        //public void AddPlayerShot(ICoordinate shot)
        //{
        //    ShotSpaces.Add(shot);
        //}
    }
}
