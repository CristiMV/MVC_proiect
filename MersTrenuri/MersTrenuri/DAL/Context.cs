using MersTrenuri.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MersTrenuri.DAL
{
    public class Context : DbContext
    {
        public Context() : base("Context") { }
        public DbSet<Tren> Trenuri{ get; set; }
        public DbSet<StatieTren> StatiiTren{ get; set; }
        public DbSet<Gara> Gari{ get; set; }
		public DbSet<Rezervare> Rezervari{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) { modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); }
    }
}

/*
using ContosoUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
*/

