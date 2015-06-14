/* Database.cs
 *database connection woth sqlite
 *
 * Revision History
 * Pranay Sheth, Dewang Patel 05.02.2015: Created
 */ 



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace WebSurvey
{
    class Database:SQLiteAsyncConnection
    {

        static public string GetDatabasePath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PersonData.db");
        }
        public Database( string databasePath) :base(databasePath,true)
        {

        }
        public async Task Init()
        {
            await CreateTableAsync<PersonalInfo>();
            await CreateTableAsync<BackgroundInfo>();
        }
    }
}
