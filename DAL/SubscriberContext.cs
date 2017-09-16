using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using webAPIAngular.Models;

namespace webAPIAngular.DAL
{
    public class SubscriberContext : DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<AcessLog> AcessLogs { get; set; }
        

        public SubscriberContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}