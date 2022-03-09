using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kart_skills
{
    internal class DBkarting
    {
        public static string connectionString = "Data Source=LAPTOP-0ITIO8EU BULKASQL;Initial Catalog=Karting;User ID=sa;Password=12345";
        private static SqlConnection connection;
        private static SqlCommand cmd;
        private static DataSet dataSet;
        private static SqlDataAdapter dataAdapter;

        
        public static string Cmd(string command)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                cmd = new SqlCommand(command, connection);
                cmd.ExecuteNonQuery();
                if (!command.StartsWith("INSERT") && !command.StartsWith("EXEC") && !command.StartsWith("BACKUP") && !command.StartsWith("USE"))
                {
                    if (cmd.ExecuteScalar() != null) return cmd.ExecuteScalar().ToString();
                    else return null;
                }
                else return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }

       
        public static DataSet FillDataSet(string command)
        {
            dataSet = new DataSet();
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                dataAdapter = new SqlDataAdapter(command, connection);
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

