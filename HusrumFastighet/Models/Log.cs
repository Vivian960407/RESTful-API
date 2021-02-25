using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Models
{
    public class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public Event Event { get; set; }
        public Tenant Tenant { get; set; }
        public Door Door { get; set; }
        public Location Location { get; set; }
    }
}
