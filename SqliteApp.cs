namespace SqliteApp
{
    using Microsoft.Data.Sqlite;
    class SqliteApp
    {
        static readonly string connectionString = "Data Source=miBase.db";
        private static string sql;

        public static void Init()
        {
            /* Crea la tabla si no existe */
            try
            {
                using SqliteConnection conn = new(connectionString);
                conn.Open();
                sql = "CREATE TABLE IF NOT EXISTS passwords (id INTEGER PRIMARY KEY AUTOINCREMENT,name TEXT NOT NULL UNIQUE, pass TEXT NOT NULL);";
                using SqliteCommand cmd = new(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error al crear la base de base de detaos");
            }
        }
        public static bool AddPassword(string name, string pass)
        {
            try
            {
                using SqliteConnection conn = new(connectionString);
                conn.Open();
                sql = "INSERT INTO passwords name, pass VALUES(@name,@pass); ";
                using SqliteCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", pass);
                var row = cmd.ExecuteNonQuery();
                return row > 0;
            }
            catch (SqliteException)
            {
                Console.WriteLine("Error al crear la base de base de detaos");
                return false;
            }
        }
    }
}