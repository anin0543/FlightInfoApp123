using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightInfoApp.Model
{
    public class FlightInfoContext:DbContext
    {
        public FlightInfoContext(DbContextOptions opts) : base(opts)
        {

        }
        public DbSet<FlightInfo> FlightInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
