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
        HouseContextFactory ContextFactory = new HouseContextFactory();
        int MaxEnteries;
        private string[] args { get; set; }
        List<Models.Log> result { get; set; } = new();
       
        public int _MaxEnteries
        {
            get { return MaxEnteries; }
            set { MaxEnteries = value; }
        }

        public List<Models.Log> FindEntriesByDoor(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var Log = dbContext.Logs
                .Where(log => log.Door.DoorCode == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToArray();

            foreach (var item in Log)
                result.Add(item);
            return result;
        }

        public List<Models.Log> FindEntriesByEvent(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var Log = dbContext.Logs
                .Where(log => log.Event.EventCode == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToArray();

            foreach (var item in Log)
                result.Add(item);
            return result;
        }

        public List<Models.Log> FindEntriesByLocation(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var Log = dbContext.Logs
                .Where(log => log.Location.Apartment == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToArray();

            foreach (var item in Log)
                result.Add(item);
            return result;
        }

        public List<Models.Log> FindEntriesByTag(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var Log = dbContext.Logs
                .Where(log => log.Tenant.Tag == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToArray();

            foreach (var item in Log)
                result.Add(item);
            return result;
        }

        public List<Models.Log> FindEntriesByTenant(string input)
        {
            using var @dbContext = ContextFactory.CreateDbContext(args);
            var Log = dbContext.Logs
                .Where(log => log.Tenant.TenantName == input)
                .Include(log => log.Tenant)
                .Include(log => log.Location)
                .Include(log => log.Event)
                .Include(log => log.Door)
                .OrderByDescending(log => log.ID)
                .Take(MaxEnteries)
                .ToArray();

            foreach (var item in Log)
                result.Add(item);
            return result;
        }
        /*
        public List<Models.Tenant> ListTenantAt(int input)
        {

        }

        public bool LogEntry(string input)
        {

        }

        public bool MoveTenant(string input1, string input2)
        {

        }

        public bool AddTenant(string input)
        {

        }
        */
    }
}
