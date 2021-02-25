using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Models
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Apartment { get; set; } = string.Empty;
        public List<Door> Doors { get; set; } = new();
        public List<Log> Log { get; set; } = new();
        public List<Tenant>? Tenant { get; set; } = new();

    }
}
