using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace tpado1
{
    class Methodes
    {
        public static SqlConnection connecter(string data)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog="+data+";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            return con;

        }
        public static void deconnecter(string data)
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=" + data + ";Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Close();
        }
        public static SqlDataReader selection(string data, string requete)
        {
            SqlConnection cn = connecter(data);
            SqlCommand cmd = new SqlCommand(requete, cn);
            SqlDataReader rd = cmd.ExecuteReader();
            return rd;
        }
        public static int misajour(string data, string requete)
        {
            SqlConnection cn = connecter(data);
            SqlCommand cmd = new SqlCommand(requete, cn);
            int rs = cmd.ExecuteNonQuery();
            return rs;
        }
    }
}
