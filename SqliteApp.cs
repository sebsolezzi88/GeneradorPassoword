namespace SqliteApp
{
    using ClassPasswordItem;
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
                sql = "INSERT INTO passwords (name, pass) VALUES(@name,@pass); ";
                using SqliteCommand cmd = new(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", pass);
                var row = cmd.ExecuteNonQuery();
                return row > 0;
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error al crear la base de base de detaos");
                return false;
            }
        }
        //Función para listar las contraseñas
        public static List<PasswordItem> GetPasswords()
        {
            List<PasswordItem> passwordItems = new();
            try
            {
                using SqliteConnection conn = new(connectionString);
                conn.Open();
                sql = "SELECT * FROM passwords;";
                using SqliteCommand cmd = new(sql,conn);
                //Ejecutamos la consulta y guardamos las tareas en el DataReader
                using SqliteDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read())
                {
                    passwordItems.Add(new PasswordItem
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Name= reader["name"].ToString()!,
                        Pass= reader["pass"].ToString()!
                        
                    });
                }
                return passwordItems;

            }
            catch (SqliteException ex)
            {
                Console.WriteLine("Error al listar los passwords");
                Console.WriteLine(ex);
                return passwordItems;
            }
        }
    }
}