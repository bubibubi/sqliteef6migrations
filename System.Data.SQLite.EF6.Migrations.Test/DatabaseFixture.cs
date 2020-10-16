using System.Data.Common;
using System.IO;

namespace System.Data.SQLite.Migrations.Test
{
    public class DatabaseFixture : IDisposable
    {
        private const string fileName = "Model01";
        private readonly string databaseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.db3");
        public DbConnection Connection { get; set; }

        public DatabaseFixture()
        {
            var connectionString = new SQLiteConnection($"Data Source={databaseFilePath};Version=3;");
            Connection = new SQLiteConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Close();
            Connection.Dispose();

            //https://stackoverflow.com/a/8513453/1872200
            GC.Collect();
            GC.WaitForPendingFinalizers();

            File.Delete(databaseFilePath);
        }
    }
}

