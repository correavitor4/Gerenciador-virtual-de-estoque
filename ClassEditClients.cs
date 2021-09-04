using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassEditClients
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        private string message = "";
        public ClassEditClients(int id,string name,string address)
        {
            try
            {
                cmd.Connection = conn.connect();

                cmd.CommandText = string.Format("UPDATE [dbo].[Clientes] SET nome='{0}',endereco='{1}' WHERE id='{2}'",name,address,id);

                cmd.ExecuteNonQuery();

                message = "Edição dos dados de cliente efetuado com sucesso";

                conn.disconnect();

            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                this.message = "Erro ao editar cadastros de cliente";
            }
        }

        public string getMessage()
        {
            return this.message;
        }

    }
}
