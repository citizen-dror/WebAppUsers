using System;
using System.Collections.Generic;
using System.Linq;
using WebAppUsers.DAL;

namespace WebAppUsers.Services
{
    public class TimeZoneService
    {
        private readonly supercomDbContext _context;

        public TimeZoneService(supercomDbContext context)
        {
            _context = context;
        }

        public List<DAL.TimeZone> getAll()
        {
            List<DAL.TimeZone> res = null;
            try
            {
                using (var db = _context)
                {
                    // Read
                    Console.WriteLine("Querying for all time zones");
                    res = db.TimeZones.OrderBy(b => b.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());
                throw new Exception(ex.ToString());
            }
            return res;
        }
    }
}
