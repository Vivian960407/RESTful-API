﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Models
{
    public class Door
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string DoorCode { get; set; } = string.Empty;
        public List<Location> Location { get; set; } = new();
        public List<Log> Log { get; set; } = new();
    }
}
