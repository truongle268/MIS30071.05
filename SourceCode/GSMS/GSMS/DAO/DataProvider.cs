using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMS.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        private string connectionSTR = @"Data Source=ZUUZOU;Initial Catalog=QLCHTH;Integrated Security=True";
        private DataProvider() { }

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }

            set
            {
                instance = value;
            }
        }

        public DataTable ExecuteQuery(string query, object[] parameters = null)
        {
            DataTable data = new DataTable();
            using ( SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] words = query.Split(' ');
                    int i = 0;
                    foreach (string word in words)
                    {
                        if (word.Contains('@'))
                        {
                            command.Parameters.AddWithValue(word, parameters[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adpater = new SqlDataAdapter(command);
                adpater.Fill(data);
                connection.Close();
            }
            return data;
        }

        internal DataTable ExecuteQuery()
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string query, object[] parameters = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] words = query.Split(' ');
                    int i = 0;
                    foreach (string word in words)
                    {
                        if (word.Contains('@'))
                        {
                            command.Parameters.AddWithValue(word, parameters[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query, object[] parameters = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    string[] words = query.Split(' ');
                    int i = 0;
                    foreach (string word in words)
                    {
                        if (word.Contains('@'))
                        {
                            command.Parameters.AddWithValue(word, parameters[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }
    }
}

