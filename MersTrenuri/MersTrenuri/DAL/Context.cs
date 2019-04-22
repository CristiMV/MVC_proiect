using MersTrenuri.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MersTrenuri.DAL
{
    public class Context : DbContext
    {
        public Context() : base("Context") { }
        public DbSet<Tren> Trenuri{ get; set; }
        public DbSet<StatieRuta> StatiiRuta{ get; set; }
        public DbSet<Gara> Gari{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) { modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); }
    }
}

/*
using ContosoUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
*/
/*
namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolContext") { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) { modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); }
    }
}
*/