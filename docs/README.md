**Project Description**  
Migrations for Entity Framework 6 SQLite provider  
  
**Limitations:**  
 - Relationships are not enforced with constraints  
 - There can be only one identity column per table and will be created as integer and primary key (other primary keys will be ignored)  
 - It supports only SQLite database file and does not work with in SQLite memory database.
  
**How to use it**  
 - Download the library (using NuGet)  
 - Create a migration configuration  
 - Setup the migration configuration (usually during first context creation)  
 
 **How do I view a table in SQLite?**
 - List the tables in your database :. tables
 - List how the table looks :. schema tablename
 - Print the entire table :. SELECT * FROM Ttablename
 - List all of the **SQLite** prompt commands :. help
  
_Example_  
  
```c#
    class Context : DbContext
    {
        static Context()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, ContextMigrationConfiguration>(true));
        }

        // DbSets
    }

    internal sealed class ContextMigrationConfiguration : DbMigrationsConfiguration<Context>
    {
        public ContextMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }
    }

```
