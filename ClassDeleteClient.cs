using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassDeleteClient
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();

        private string message = "";

        public ClassDeleteClient(int clientId)
        {
            try
            {
                //recebe o endereço da conexão 
                cmd.Connection = conn.connect();
                cmd.CommandText = string.Format("DELETE FROM [dbo].[Clientes] WHERE [id]='{0}'", clientId);

                cmd.ExecuteNonQuery();

                this.message = "O cliente foi excluído com sucesso";

                conn.disconnect();

            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

        }

        public string getMessage()
        {
            return this.message;
        }
    }
}
