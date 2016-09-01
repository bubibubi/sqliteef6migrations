using System;
using System.Data.Common;
using System.Linq;

namespace System.Data.SQLite.EF6.Migrations.Test.Model01
{
    class Test
    {
        public static void Run(DbConnection connection)
        {
            using (var context = new Context(connection))
            {
                Console.WriteLine(context.Entities.Count());

                context.Dependants.Add(new Dependant() {Description = "Dependant description", MainEntity = new EF6.Migrations.Test.Model01.Entity() {Description = "Entity description"}});
                context.SaveChanges();

            }
        }
    }
}
