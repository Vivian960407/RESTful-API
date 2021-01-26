using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Database
{
    /// <summary>
    /// This is the class in which the Database happens, the class inherits from DbContext
    /// an intermediate class designed by EF to bridge between C# and the Database
    /// Class' properties represent tables in the Database, lists that contain objects from the Model classes
    /// There's also a constructor which allows to use instances of the class outside of it with ease 
    /// </summary>
    class HouseContext : DbContext
    {
        public DbSet<Models.Tenant> Tenants { get; set; }
        public DbSet<Models.Log> Logs { get; set; }
        public DbSet<Models.Location> Locations { get; set; }
        public DbSet<Models.Event> Events { get; set; }
        public DbSet<Models.Door> Doors { get; set; }

        public HouseContext(DbContextOptions<HouseContext> options) : base(options) { }

    }
}
