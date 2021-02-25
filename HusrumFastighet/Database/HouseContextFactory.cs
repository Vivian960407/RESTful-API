using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Database
{
    /// <summary>
    /// The following class generates the database and its data, providing a connection to the database allows the program 
    /// to manipulate, create, remove, search ect data in the database
    /// Its only method is inherited from the Inumarable IDesignTimeContextFactory interface in respect of the HouseContext class aka
    /// the Database class 
    /// </summary>
    class HouseContextFactory : IDesignTimeDbContextFactory<HouseContext>
    {
        public HouseContext CreateDbContext(string[] args)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), @"VivianHouse.db");
            var optionBuilder = new DbContextOptionsBuilder<HouseContext>();
            optionBuilder.UseSqlite($"Data Source = {path}");
            return new HouseContext(optionBuilder.Options);
        }
    }
}
