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
        public List<string> players { get; set; }
    }
}
