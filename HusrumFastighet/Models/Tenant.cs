using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Models
{
    public class Tenant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? ApartmentID { get; set; } 
        public Location? Apartment { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public string? Tag { get; set; } = string.Empty;
        public List<Log> Log { get; set; } = new();
    }
}
