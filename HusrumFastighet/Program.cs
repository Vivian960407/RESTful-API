using HusrumFastighet.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HusrumFastighet
{
    class Program
    {
        static void Main()
        {
            Database.DatabaseSeeder databaseSeeder = new Database.DatabaseSeeder();
            databaseSeeder.Seeder();

            View.Output.Test_Run();
            
        }
    }
}
