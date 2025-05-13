using System.Data;
using MySql.Data.MySqlClient;

namespace Flamed.Scripts.SQL
{
    public class Engine
    {
        private const string _str = "Server=localhost;Port=3307;Database=Flamed;Uid=guest;Pwd=guest;";
        private static MySqlConnection _conn;

        public Engine()
        {
            try
            {
                _conn = new MySqlConnection(_str);
                _conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static ConnectionState GetState()
        {
            return _conn.State;
        }

        public static DataTable ExecuteQuery(string sql)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    cmd.CommandText = sql;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new DataTable();
        }

        public static object ExecuteQueryScalar(string sql)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, _conn))
                {
                    cmd.CommandText = sql;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new object();
        }
    }
}