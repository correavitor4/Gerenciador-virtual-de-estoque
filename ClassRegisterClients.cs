using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassRegisterClients
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        private string message = "";


        public ClassRegisterClients(string name,string address)
        {
            try
            {
                cmd.Connection = conn.connect();
                cmd.CommandText = string.Format("INSERT INTO [dbo][Clientes] (nome,endereco) VALUES('{0}','{1}')",name,address);

                cmd.ExecuteNonQuery();

                this.message = "Inserção do cliente na tabela teve sucesso";

                conn.disconnect();
            }
            catch(SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            
        }

        private string  getMessage()
        {
            return this.message;
        }
    }
}
