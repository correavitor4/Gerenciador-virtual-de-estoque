using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    public class ConnectionDB
    {
        SqlConnection connection = new SqlConnection();
        //CONSTRUTOR
        public ConnectionDB()
        {
            connection.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C: \\Users\\corre\\source\repos\\Gerenciador -virtual-de-estoque\\Database1.mdf;Integrated Security = True";
        }
        //MÉTODO DE CONEXÃO 

        public SqlConnection connect()
        {
            //verifica se a conexão ainda não está aberta
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            
            return connection;
        }
        //MÉTODO DE DESCONEXÃO
        public void disconnect()
        {
            //verifica se a conexão está aberta
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

    }
}
