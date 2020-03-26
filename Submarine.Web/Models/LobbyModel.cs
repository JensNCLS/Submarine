using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Submarine.Web.Models
{
    public class LobbyModel
    {
        [Required] public string lobbyCode { get; set; }
        private List<PlayerModel> players { get; set; }

        public LobbyModel()
        {
            players = new List<PlayerModel>()
            {
                new PlayerModel() {username = "Roelie"},
                new PlayerModel() {username = "GrayNolygie"}
            };
        }
        public List<PlayerModel> GetAllPlayers()
        {
            return players;
        }
    }
}
