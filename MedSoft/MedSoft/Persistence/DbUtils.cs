using System;
using System.Data;
using System.Data.SQLite;
using System.Reflection;


namespace Persistence {
    public static class DbUtils {
        private static IDbConnection instance = null;

        public static IDbConnection getConnection() {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed) {
                instance = getNewConnection();
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection() {
            return ConnectionFactory.getInstance().createConnection();
        }
    }

    public abstract class ConnectionFactory {
        protected ConnectionFactory() { }
        private static ConnectionFactory instance;
        public static ConnectionFactory getInstance() {
            if (instance == null) {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type[] types = assembly.GetTypes();
                foreach (var type in types) {
                    if (type.IsSubclassOf(typeof(ConnectionFactory))) {
                        instance = (ConnectionFactory)Activator.CreateInstance(type);
                    }
                }
            }
            return instance;
        }
        public abstract IDbConnection createConnection();
    }

    public class SqliteConnectionFactory : ConnectionFactory {
        public override IDbConnection createConnection() {
            //edit db location with absolute path of "medsoft.db" file
            string connectionString = "Data Source=D:\\Programming\\personal_projects\\git\\Medsoft_BachelorApp\\MedSoft\\medsoft.db; Version = 3;";
            Console.WriteLine("Creating sqlite connection .................");
            return new SQLiteConnection(connectionString);
        }
    }
}
