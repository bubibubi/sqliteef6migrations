using System.Data.Common;
using System.Data.Entity;

namespace System.Data.SQLite.EF6.Migrations.Test.Models
{
    class Context : DbContext
    {
        static Context() => 
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, ContextMigrationConfiguration>(true));

        public Context(DbConnection connection) : base(connection, false) { }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<Dependant> Dependants { get; set; }
    }
}

