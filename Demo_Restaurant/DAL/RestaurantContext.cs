using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Demo_Restaurant.DAL
{
    public class RestaurantContext: DbContext
    {
        public RestaurantContext() : base("RestaurantContext")
        {
        }

        public DbSet<Models.Recipe> Recipes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}