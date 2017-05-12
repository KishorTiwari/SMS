using System;
using System.Collections.Generic;
using System.Text;
using SMS.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SMS.Data.DAL
{
    public class SMSContext: DbContext
    {
        public SMSContext(): base("Name=SMSContext")
        {

        }
        public DbSet<Trader> Trader { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<ExtraCost> ExtraCost { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
