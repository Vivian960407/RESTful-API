using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Models
{
    class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string EventCode { get; set; } = string.Empty;
        public string? Note { get; set; }
        public string? Note2 { get; set; }
        public List<Log> Log { get; set; } = new();
    }
}
