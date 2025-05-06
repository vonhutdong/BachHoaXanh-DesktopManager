using System;

namespace DAL
{
    public class DatabaseAccess
    {
        public QLBHXDataContext Db { get; private set; }
        public string ServerName { get; private set; }
        public string DbName { get; private set; }

        public DatabaseAccess()
        {
            // Lấy từ Settings.settings (chứ không lấy từ App.config)
            Db = new QLBHXDataContext(Properties.Settings.Default.SieuThiBHXConnectionString);
        }

        public DatabaseAccess(QLBHXDataContext db, string serverName, string dbName)
        {
            this.Db = db;
            this.ServerName = serverName;
            this.DbName = dbName;
        }
    }
}
