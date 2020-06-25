using Submarine.GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Submarine.GameLogic.Helpers
{
    // Enumerables
    public enum ValidateShotResult
    {
        Unvalidated,
        Valid,
        InvalidShotOnSelf,
        InvalidDuplicateShot

    }


    public class ShotValidationHelper
    {
        // Methods
        /// <summary>
        /// Validates the shot that has been made
        /// </summary>
        /// <param name="coordinate"></param>
        /// <param name="currentPlayer"></param>
        /// <param name="battlefield"></param>
        /// <returns></returns>
        public ValidateShotResult ValidateShot(ICoordinate coordinate, IPlayer currentPlayer, IBattlefield battlefield)
        {
            // Check on dupe shots
            var dupeShot = CheckOnDuplicateShot(coordinate, currentPlayer.ShotSpaces);
            if (dupeShot)
            { return ValidateShotResult.InvalidDuplicateShot; }

            // Check on self shooting
            var shotOnSelf = CheckOnSelfShooting(coordinate, currentPlayer.PlayerId, battlefield);
            if (shotOnSelf)
            { return ValidateShotResult.InvalidShotOnSelf; }

            if (!dupeShot && !shotOnSelf)
            { return ValidateShotResult.Valid; }

            return ValidateShotResult.Unvalidated;
        }


        /// <summary>
        /// Checks if the shot has already been made 
        /// </summary>
        /// <param name="coordinate">The coordinate the player shot at</param>
        /// <param name="previouslyShotCoordinates">A list of previously shot coordinates</param>
        /// <returns>Returns 'True' if the shot is a duplicate and 'False' if the shot hasn't been made before</returns>
        private bool CheckOnDuplicateShot(ICoordinate coordinate, List<ICoordinate> previouslyShotCoordinates)
        {
            var dupeshot = previouslyShotCoordinates.Where(c => c.X == coordinate.X && c.Y == coordinate.Y).FirstOrDefault();
            if (dupeshot != null)
            {
                Debug.WriteLine("ShotValidationHelper - CheckOnDuplicateShot - Shot on (" + coordinate.X + ", " + coordinate.Y + ") has already been made - DUPE");
                return true;
            }
            else
            {
                Debug.WriteLine("ShotValidationHelper - CheckOnDuplicateShot - Shot on (" + coordinate.X + ", " + coordinate.Y + ") is original - OG SHOT");
                return false;
            }
        }


        /// <summary>
        /// Checks if the player the current player shot at isn't themself
        /// </summary>
        /// <param name="coordinate">The coordinate the player shot at</param>
        /// <param name="CurrentPlayerId">The player who shot the shot</param>
        /// <returns>Returns 'True' if the player shot themself and 'False' if they didn't shot themself</returns>
        private bool CheckOnSelfShooting(ICoordinate coordinate, int CurrentPlayerId, IBattlefield battlefield)
        {
            var playerId = battlefield.CheckPlayerLocation(coordinate);
            if (playerId == CurrentPlayerId)
            {
                Debug.WriteLine("ShotValidationHelper - CheckOnSelfShooting - Player shot on self");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
