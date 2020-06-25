using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Submarine.Web.Models
{
    public class PlayerModel
    {
        [Required] public string username { get; set; }
    }
}
