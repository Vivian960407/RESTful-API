using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.View
{
    class Output
    {

        /// <summary>
        /// A test run method to just show that the program works 
        /// </summary>
        public static void Test_Run()
        {
            var test = new Controller.DoorEventsLog();
            test._MaxEnteries = 20;

            var result = test.FindEntriesByDoor("LGH0302");
            foreach (var item in result)
                Console.WriteLine($"\nSearch by door: {item.Date}\t{item.Time}\t{item.Event.EventCode}\t{item.Location.Apartment}\t{item.Tenant.Tag}\t{item.Tenant.TenantName}  {item.Event.Note} {item.Door.DoorCode} {item.Event.Note2} ");
            result = test.FindEntriesByLocation("0201");
            foreach (var item in result)
                Console.WriteLine($"\nSearch by location: {item.Date}\t{item.Time}\t{item.Event.EventCode}\t{item.Location.Apartment}\t{item.Tenant.Tag}\t{item.Tenant.TenantName}  {item.Event.Note} {item.Door.DoorCode} {item.Event.Note2} ");
            result = test.FindEntriesByTenant("Lucas Adolfsson");
            foreach (var item in result)
                Console.WriteLine($"\nSearch by tenant: {item.Date}\t{item.Time}\t{item.Event.EventCode}\t{item.Location.Apartment}\t{item.Tenant.Tag}\t{item.Tenant.TenantName}  {item.Event.Note} {item.Door.DoorCode} {item.Event.Note2} ");
            result = test.FindEntriesByTag("0302A");
            foreach (var item in result)
                Console.WriteLine($"\nSearch by tag: {item.Date}\t{item.Time}\t{item.Event.EventCode}\t{item.Location.Apartment}\t{item.Tenant.Tag}\t{item.Tenant.TenantName}  {item.Event.Note} {item.Door.DoorCode} {item.Event.Note2} ");
            result = test.FindEntriesByEvent("DÖIN");
            foreach (var item in result)
                Console.WriteLine($"\nSearch by event: {item.Date}\t{item.Time}\t{item.Event.EventCode}\t{item.Location.Apartment}\t{item.Tenant.Tag}\t{item.Tenant.TenantName}  {item.Event.Note} {item.Door.DoorCode} {item.Event.Note2} ");
        }
    }
}
