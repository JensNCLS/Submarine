﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class PlayerDto
    {
        public int userId { get; set; }

        [Required(ErrorMessage = "player name is required")]
        public string name { get; set; }
    }
}
