using HusrumFastighet.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HusrumFastighet.Controller
{
    class DoorEventsLog
    {
        /// <summary>
        /// The only intressting property here is MaxEntries which needs to get asigned a value whenever 
        /// the search methods are going to get used. It indicates the number of rows that will appear in
        /// search results (aka number of elements in the result list)
        /// </summary>
        HouseContextFactory ContextFactory = new HouseContextFactory();

        int MaxEnteries;

        private string[] args { get; set; }

        List<Models.Log> result { get; set; } = new();
       
        public int _MaxEnteries
        {
            get { return MaxEnteries; }
            set { MaxEnteries = value; }
        }

        /// <summary>
        /// The Following Methods named Find... are pretty much self explanatory
        /// Give them for ex a door and they give you all logs aka entries trough that door
        /// and so on
        /// </summary>
        public List<Models.Log> FindEntriesByDoor(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var log = dbContext.Logs
                .Where(log => log.Door.DoorCode == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToList();

            return log;
        }

        public List<Models.Log> FindEntriesByEvent(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var log = dbContext.Logs
                .Where(log => log.Event.EventCode == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToList();

            return log;
        }

        public List<Models.Log> FindEntriesByLocation(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var log = dbContext.Logs
                .Where(log => log.Location.Apartment == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToList();

            return log;
        }

        public List<Models.Log> FindEntriesByTag(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var log = dbContext.Logs
                .Where(log => log.Tenant.Tag == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToList();

            return log;
        }

        public List<Models.Log> FindEntriesByTenant(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var log = dbContext.Logs
                .Where(log => log.Tenant.TenantName == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToList();
            
            return log;
        }
        
        /// <summary>
        /// This method takes an apartment number and gives back all the tenants who live there
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Models.Tenant> ListTenantAt(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var tenant = dbContext.Tenants
                .Where(t => t.Apartment.Apartment == input)
                .ToList();

            return tenant;
        }

        /// <summary>
        /// date format: ddmmyyyy
        /// time format: hhmm
        /// ***
        /// The method can be used to register new logs if imaginary for exampel tenants or locations
        /// are sent to this method, the log will not get registered and it will return a false bool
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="tenantName"></param>
        /// <param name="apartment"></param>
        /// <param name="door_"></param>
        /// <param name="event_"></param>
        /// <returns></returns>
        public bool LogEntry(int date, int time, string tenantName, string apartment, string door_, string event_)
        {
            bool taskSuccession = true;
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var tenant = dbContext.Tenants.FirstOrDefault(t => t.TenantName == tenantName);
            var location = dbContext.Locations.FirstOrDefault(l => l.Apartment == apartment);
            var door = dbContext.Doors.FirstOrDefault(d => d.DoorCode == door_);
            var @event = dbContext.Events.FirstOrDefault(e => e.EventCode == event_);
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                if (tenant != null && location != null && door != null && @event != null)
                {
                    dbContext.Logs.Add(new Models.Log { Date = date, Time = time, Door = door, Location = location, Tenant = tenant, Event = @event });
                    dbContext.SaveChanges();
                    transaction.Commit();
                    return taskSuccession;
                }
                else
                    return taskSuccession = false;
            }
            catch (Exception)
            {
                return taskSuccession = false;
            }
        }

        /// <summary>
        /// This one either takes in a name/tag and an empty string in order to register the tenant's departure 
        /// or takes in a name/tag and an apartment number in order to register the tenant's residency in that apartment
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        public bool MoveTenant(string input1, string input2)
        {
            bool taskSuccession = true;
            char character = input1.ToCharArray().ElementAt(0);
            using var @dbContext = ContextFactory.CreateDbContext(args);
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
               if (String.IsNullOrEmpty(input2))
                {
                    if (char.IsNumber(character))
                    {
                        var tenant = dbContext.Tenants.FirstOrDefault(t => t.Tag == input1);
                        //var apartment = dbContext.Locations.FirstOrDefault(l => l == tenant.Apartment);

                        tenant.Tag = null;
                        tenant.ApartmentID = null;
                    }
                    if (!char.IsNumber(character))
                    {
                        var tenant = dbContext.Tenants.FirstOrDefault(t => t.TenantName == input1);
                        tenant.Tag = null;
                        tenant.ApartmentID = null;
                    }
                }
                else
                {
                    if (char.IsNumber(character))
                    {
                        var tenant = dbContext.Tenants.FirstOrDefault(t => t.Tag == input1);
                        var apartment = dbContext.Locations.FirstOrDefault(l => l.Apartment == input2);
                        var tenantList = ListTenantAt(input2);
                        List<string> occupiedTags = new();
                        char @char = 'a';
                        foreach (var item in tenantList)
                        {
                            if (item.Tag != null)
                                occupiedTags.Add(item.Tag);
                        }
                        for (int i = 65; i < 90; i++)
                        {
                            @char = (char)i;
                            int control = 0;
                            foreach (var item in occupiedTags)
                            {
                                char comparison = item.ToCharArray().ElementAt(4);
                                if (@char == comparison)
                                    break;
                                else
                                    control++;
                            }
                            if (control != occupiedTags.Count)
                                continue;
                            else
                                break;
                        }
                    
                        tenant.Tag = input2 + @char;
                        tenant.Apartment = apartment;
                    }
                    if (!char.IsNumber(character))
                    {
                        var tenant = dbContext.Tenants.FirstOrDefault(t => t.TenantName == input1);
                        var apartment = dbContext.Locations.FirstOrDefault(l => l.Apartment == input2);
                        var tenantList = ListTenantAt(input2);
                        List<string> occupiedTags = new();
                        char @char = 'a';
                        foreach (var item in tenantList)
                        { 
                            if(item.Tag!=null)
                            occupiedTags.Add(item.Tag); 
                        }
                        for (int i = 65; i < 90; i++)
                        {
                            @char = (char)i;
                            int control = 0;
                            foreach (var item in occupiedTags)
                            {
                                char comparison = item.ToCharArray().ElementAt(4);
                                if (@char == comparison)
                                    break;
                                else
                                    control++;
                            }
                            if (control != occupiedTags.Count)
                                continue;
                            else
                                break;
                        }
                        
                        tenant.Tag = input2 + @char;
                        tenant.Apartment = apartment;
                    }
                }
                dbContext.SaveChanges();
                transaction.Commit();
                return taskSuccession;
            }
            catch (Exception)
            {
                return taskSuccession = false;
            }
        }

        /// <summary>
        /// Really and literally takes a name and adds it as a new tenant to the tenant table, will be used 
        /// when a tenant hasn't been assigned a tag or an apartment 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool AddTenant(string input)
        {
            bool taskSuccession = true;
            using var @dbContext = ContextFactory.CreateDbContext(args);
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                    dbContext.Tenants.Add(new Models.Tenant { TenantName = input});
                    dbContext.SaveChanges();
                    transaction.Commit();
                    return taskSuccession;
            }
            catch (Exception)
            {
                return taskSuccession = false;
            }
        }
        
    }
}
