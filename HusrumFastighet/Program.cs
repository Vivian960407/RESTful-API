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
            //Database.DatabaseSeeder databaseSeeder = new Database.DatabaseSeeder();
            //var Test = databaseSeeder;
            //Test.Seeder();

            var Test = new Controller.DoorEventsLog();
            Test._MaxEnteries = 20;
            var Result = Test.FindEntriesByLocation("0301");
            foreach (var item in Result)
                Console.WriteLine($"x {item.Tenant.TenantName} time {item.Time} lala {item.Location.Apartment}");
        }
    }
}
