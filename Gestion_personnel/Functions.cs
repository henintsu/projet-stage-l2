using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Gestion_personnel
{
    class Functions
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConString;

        public Functions()
        {
            ConString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\acer\Documents\TestDB.mdf;Integrated Security=True;Connect Timeout=30";
            con = new SqlConnection(ConString);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public DataTable RecupererDonnees(string Req)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Req, ConString);
            sda.Fill(dt);
            return dt;
        }

        public DataTable RecupererDonnees(string req, Dictionary<string, object> parameters = null)
        {
           // Exemple d'implémentation avec SqlConnection et SqlDataAdapter
            using (SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\acer\Documents\TestDB.mdf; Integrated Security = True; Connect Timeout = 30"))
            {
                using (SqlCommand command = new SqlCommand(req, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                        }
                    }

                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public int EnvoyerDonnees(string Req)
        {
            int cnt = 0;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.CommandText = Req;
            cnt = cmd.ExecuteNonQuery();
            con.Close();

            return cnt;
        }

        public int EnvoyerDonnees(string Req, Dictionary<string, object> parameters)
        {
            int cnt = 0;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.Parameters.Clear();
            cmd.CommandText = Req;

            // Ajouter les paramètres de requête
            foreach (var parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            cnt = cmd.ExecuteNonQuery();
            con.Close();

            return cnt;
        }

        public int RecupererDonneesScalar(string req, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(req, connection))
                {
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, object> param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0; // Retourner 0 si le résultat est null ou DBNull.Value
                }
            }
        }

        internal int RecupererDonneesScalar<T>(string req, Dictionary<string, object> dictionary)
        {
            throw new NotImplementedException();
        }


    }

}
