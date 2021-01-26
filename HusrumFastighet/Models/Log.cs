using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Models
{
    class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Time { get; set; }
        public int Date { get; set; }
        public Event Event { get; set; }
        public Tenant Tenant { get; set; }
        public Door Door { get; set; }
        public Location Location { get; set; }
    }
}
