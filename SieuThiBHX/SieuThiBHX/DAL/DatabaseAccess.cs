using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseAccess
    {
        private QLBHXDataContext db = new QLBHXDataContext();
        private string serverName = ".\\SQLEXPRESS";
        private string dbName = "SieuThiBHX";
        public DatabaseAccess(QLBHXDataContext db, string serverName, string dbName)
        {
            this.db = db;
            this.serverName = serverName;
            this.dbName = dbName;
        }
        public DatabaseAccess()
        {
            Db = new QLBHXDataContext(Properties.Settings.Default.SieuThiBHXConnectionString);
        }
        public QLBHXDataContext Db { get; set; }
        public string ServerName { get; set; }
        public string DbName { get; set; }
    }
}
