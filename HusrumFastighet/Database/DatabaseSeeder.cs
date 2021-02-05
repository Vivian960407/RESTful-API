using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Database
{
    /// <summary>
    /// A classic Seeder class
    /// </summary>
    class DatabaseSeeder
    {
        ///This property doesn't serve a real purpose besides that the CreatDbContext method from factory-class requires it as in-parameters 
        private string[] args { get; set; }

        /// <summary>
        ///The Seeder method, if the database doesn't exist, creats it manually in the current directory(Bin) 
        ///Which does not require to run the Update-Database cmd and until there are no further changes in Models 
        ///there would be no need to run Add-Migration cmd either
        ///Further the Seeder method fills in tables with some mock data and there're some mock logs coded in here 
        ///Transactions are used for adding value processes in order to make the program more robust and prohibit crashes
        /// </summary>
       
        public void Seeder()
        {

            FileInfo file = new FileInfo(@".\House.db");
            if (!file.Exists)
            {
                var contextFactory = new HouseContextFactory();
                using (var @dbContext = contextFactory.CreateDbContext(args))
                {
                    @dbContext.Database.Migrate();
                }

                using var context = contextFactory.CreateDbContext(args);
                using var transaction = context.Database.BeginTransaction();
                try
                {
                    //DOORS
                    Models.Door D1, D2, D3, D4, D5, D6, D7, D8, D9, DA, DB, DC, DD, DE, DF, DG, DH, DI;
                    context.Doors.AddRange(new[] {
                    D1 = new Models.Door (){ DoorCode = "LGH0101"},
                    D2 = new Models.Door (){ DoorCode = "BLK0101"},
                    D3 = new Models.Door (){ DoorCode = "LGH0102"},
                    D4 = new Models.Door (){ DoorCode = "BLK0102"},
                    D5 = new Models.Door (){ DoorCode = "LGH0103"},
                    D6 = new Models.Door (){ DoorCode = "BLK0103"},
                    D7 = new Models.Door (){ DoorCode = "LGH0201"},
                    D8 = new Models.Door (){ DoorCode = "BLK0201"},
                    D9 = new Models.Door (){ DoorCode = "LGH0202"},
                    DA = new Models.Door (){ DoorCode = "BLK0202"},
                    DB = new Models.Door (){ DoorCode = "LGH0301"},
                    DC = new Models.Door (){ DoorCode = "BLK0301"},
                    DD = new Models.Door (){ DoorCode = "LGH0302"},
                    DE = new Models.Door (){ DoorCode = "BLK0302"},
                    DF = new Models.Door (){ DoorCode = "VAKT"},
                    DG = new Models.Door (){ DoorCode = "TVÄTT"},
                    DH = new Models.Door (){ DoorCode = "SOPRUM"},
                    DI = new Models.Door (){ DoorCode = "UT"},
                });
                    context.SaveChanges();

                    //LOCATIONS
                    Models.Location L1, L2, L3, L4, L5, L6, L7, L8, L9, LA, LB;
                    context.Locations.AddRange(new[]{
                    L1 = new Models.Location (){ Apartment = "0101", Doors = new(){D1, D2}},
                    L2 = new Models.Location (){ Apartment = "0102", Doors = new(){D3, D4}},
                    L3 = new Models.Location (){ Apartment = "0103", Doors = new(){D5, D6}},
                    L4 = new Models.Location (){ Apartment = "0201", Doors = new(){D7, D8}},
                    L5 = new Models.Location (){ Apartment = "0202", Doors = new(){D9, DA}},
                    L6 = new Models.Location (){ Apartment = "0301", Doors = new(){DB, DC}},
                    L7 = new Models.Location (){ Apartment = "0302", Doors = new(){DD, DE}},

                    L8 = new Models.Location (){ Apartment = "VAKT", Doors = new(){DF}},
                    L9 = new Models.Location (){ Apartment = "TVÄTT", Doors = new(){DG}},
                    LA = new Models.Location (){ Apartment = "SOPRUM", Doors = new(){DH}},
                    LB = new Models.Location (){ Apartment = "UT", Doors = new(){DI}},
                });
                    context.SaveChanges();

                    //TENANTS
                    Models.Tenant T1, T2, T3, T4, T5, T6, T7, T8, T9, TA, TB, TC, TD, TE, TF, TG, TH, TI, TJ, TK, TL;
                    context.Tenants.AddRange(new[]
                    {
                    T1 = new Models.Tenant (){ Apartment = L1, TenantName= "Liam Jönsson", Tag = "0101A"},
                    T2 = new Models.Tenant (){ Apartment = L2, TenantName= "Elias Petterson", Tag = "0102A"},
                    T3 = new Models.Tenant (){ Apartment = L2, TenantName= "Wilma Johansson", Tag = "0102B"},
                    T4 = new Models.Tenant (){ Apartment = L3, TenantName= "Alicia Sanchez", Tag = "0103A"},
                    T5 = new Models.Tenant (){ Apartment = L3, TenantName= "Aaron Sanchez", Tag = "0103B"},
                    T6 = new Models.Tenant (){ Apartment = L4, TenantName= "Olivia Erlander", Tag = "0201A"},
                    T7 = new Models.Tenant (){ Apartment = L4, TenantName= "William Erlander", Tag = "0201B"},
                    T8 = new Models.Tenant (){ Apartment = L4, TenantName= "Alexander Erlander", Tag = "0201C"},
                    T9 = new Models.Tenant (){ Apartment = L4, TenantName= "Astrid Erlander", Tag = "0201D"},
                    TA = new Models.Tenant (){ Apartment = L5, TenantName= "Lucas Adolfsson", Tag = "0202A"},
                    TB = new Models.Tenant (){ Apartment = L5, TenantName= "Ebba Adolfsson", Tag = "0202B"},
                    TC = new Models.Tenant (){ Apartment = L5, TenantName= "Lilly Adolfsson", Tag = "0202C"},
                    TD = new Models.Tenant (){ Apartment = L6, TenantName= "Ella Ahlström", Tag = "0301A"},
                    TE = new Models.Tenant (){ Apartment = L6, TenantName= "Alma Alfredsson", Tag = "0301B"},
                    TF = new Models.Tenant (){ Apartment = L6, TenantName= "Elsa Alhström", Tag = "0301C"},
                    TG = new Models.Tenant (){ Apartment = L6, TenantName= "Maja Ahlström", Tag = "0301D"},
                    TH = new Models.Tenant (){ Apartment = L7, TenantName= "Noah Almgren", Tag = "0302A"},
                    TI = new Models.Tenant (){ Apartment = L7, TenantName= "Adam Andersen", Tag = "0302B"},
                    TJ = new Models.Tenant (){ Apartment = L7, TenantName= "Kattis Backman", Tag = "0302C"},
                    TK = new Models.Tenant (){ Apartment = L7, TenantName= "Oscar Chen", Tag = "0302D"},
                    TL = new Models.Tenant (){ Apartment = L8, TenantName= "Vaktmästare", Tag = "VAKT01"},
                });
                    context.SaveChanges();

                    //EVENTS
                    Models.Event E1, E2, E3, E4;
                    context.Events.AddRange(new[]{
                    E1 = new Models.Event { EventCode = "DÖIN" , Note = "öppnade dörren till", Note2 = "utifrån"},
                    E2 = new Models.Event { EventCode = "DÖUT" , Note = "öppnade dörren till", Note2 = "inifrån"},
                    E3 = new Models.Event { EventCode = "FDIN" , Note = "försökte öppna dörren tiil", Note2 = "utifrån"},
                    E4 = new Models.Event { EventCode = "FDUT" , Note = "försökte öppna dörren till", Note2 = "inifrån"},
                });
                    context.SaveChanges();


                    //MOCK-LOGG
                    context.Logs.AddRange(new[]{
                    new Models.Log { DateTime = new DateTime(2020,10,23,11,04,0)  , Door = DB, Location = L6, Tenant = TG, Event = E1},
                    new Models.Log { DateTime = new DateTime(2020,10,23,11,03,0) , Door = DB, Location = L6, Tenant = TG, Event = E2},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,56,0) , Door = D9, Location = L5, Tenant = TA, Event = E1},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,55,0) , Door = D9, Location = L5, Tenant = TA, Event = E2},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,22,0) , Door = DD, Location = L7, Tenant = TH, Event = E1},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,21,0) , Door = DH, Location = LA, Tenant = TH, Event = E2},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,20,0) , Door = DI, Location = LB, Tenant = T6, Event = E2},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,20,0) , Door = DH, Location = LA, Tenant = TH, Event = E1},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,19,0) , Door = D7, Location = L4, Tenant =T6, Event = E2},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,19,0) , Door = DD, Location = L7, Tenant = TH, Event = E2},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,08,0) , Door = D7, Location = L4, Tenant = T7, Event = E1},
                    new Models.Log { DateTime = new DateTime(2020,10,23,10,07,0) , Door = D7, Location = L4, Tenant = T7, Event = E2},

                });
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }
            }

        }
    }
}
