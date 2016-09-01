using System;

namespace System.Data.SQLite.EF6.Migrations
{
    static class SQLiteProviderManifestHelper
    {
        public const int MaxObjectNameLength = 255;

        /// <summary>
        /// Quotes an identifier
        /// </summary>
        /// <param name="name">Identifier name</param>
        /// <returns>The quoted identifier</returns>
        internal static string QuoteIdentifier(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            return "\"" + name.Replace("\"", "\"\"") + "\"";
        }
    }
}
