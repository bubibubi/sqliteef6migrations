using System.Data.Common;
using System.Data.SQLite.EF6.Migrations.Test.Models;
using System.Linq;
using Xunit;

namespace System.Data.SQLite.Migrations.Test
{
    public class MigrationTest : IClassFixture<DatabaseFixture>
    {
        //Shared Context between Tests https://xunit.github.io/docs/shared-context.html
        private readonly DatabaseFixture databaseFixture;

        public MigrationTest(DatabaseFixture databaseFixture) => this.databaseFixture = databaseFixture;

        [Fact]
        public void UseAutoMigration_AutomaticMigrationsEnabled_TablesCreated()
        {
            var expectedTableNames = new[] { "Dependants", "sqlite_sequence", "Entities", "__MigrationHistory" };
            var tableNames = GetAllTableNames(databaseFixture.Connection);
            Assert.Equal(expectedTableNames, tableNames);
        }

        [Fact]
        public void UseAutoMigration_WithInMemoryDatabase_TablesNotCreated()
        {
            var inMemoryDatabaseConnection = new SQLiteConnection("Data Source=:memory:;Version=3;New=True");
            var tableNames = GetAllTableNames(inMemoryDatabaseConnection);
            Assert.Empty(tableNames);
        }

        [Fact]
        public void AddEntity_AutomaticMigrationsEnabled_EntityAdded()
        {
            using (var context = new Context(databaseFixture.Connection))
            {
                context.Dependants.Add(
                    new Dependant()
                    {
                        Description = "Dependant description",
                        MainEntity = new EF6.Migrations.Test.Models.Entity()
                        {
                            Description = "Entity description"
                        }
                    });
                context.SaveChanges();
                Assert.Equal(1, context.Entities.Count());
            }

            using (var context = new Context(databaseFixture.Connection))
            {
                Assert.Equal(1, context.Entities.Count());
            }
        }

        private static string[] GetAllTableNames(DbConnection connection)
        {
            using (var context = new Context(connection))
            {
                return context.Database.SqlQuery<string>(
                    "SELECT name as TableName FROM sqlite_master WHERE type = 'table'"
                ).ToArray();
            }
        }
    }
}

