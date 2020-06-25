﻿using Entities.DataModels;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Transfer
    {
        public QueueData QueueData { get; set; }
        public string message { get; set; }
        public MessageType type { get; set; }

    }
}
