using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassRemoveProduct
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();

        private string message = "";
        public ClassRemoveProduct(int id)
        {
            try
            {
                //Recebe o endereço da conexão
                cmd.Connection = conn.connect();

                cmd.CommandText = string.Format("DELETE FORM [dbo].[Table] WHERE [id]='{0}'", id);
                //executa (sem leitura, apenas execução)
                cmd.ExecuteNonQuery();

                //disconecta do banco 
                conn.disconnect();

                this.message = "Exclusão no banco efetuada com sucesso";
                
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
