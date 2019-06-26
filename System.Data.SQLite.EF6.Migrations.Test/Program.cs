using System.Data.Common;
using System.IO;

namespace System.Data.SQLite.EF6.Migrations.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Model01_SQLite();
        }

        private static void Model01_SQLite()
        {
            DbConnection connection = GetConnection("Model01");
            EF6.Migrations.Test.Model01.Test.Run(connection);
        }

        private static DbConnection GetConnection(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".db3");
            DbConnection connection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", filePath));
            return connection;
        }
    }
}
