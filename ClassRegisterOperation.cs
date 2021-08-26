using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    
    class ClassRegisterOperation
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();


        private string message = "";

        public ClassRegisterOperation(int idProduct,string operationType,string description,string relatory)
        {
            try
            {
                //Recebe o endereço da conexão
                cmd.Connection = conn.connect();

                if (!String.IsNullOrEmpty(relatory))
                {
                    cmd.CommandText = string.Format("INSERT INTO [dbo].[operations] (Id-product,descricao,tipo-operacao,relatorio) values ('{0}','{1}','{2}','{3}')", idProduct, description, operationType, relatory);
                }
                else
                {
                    cmd.CommandText = string.Format("INSERT INTO [dbo].[operations] (Id-product,descricao,tipo-operacao) values ('{0}','{1}','{2}')", idProduct, description, operationType);
                }

                cmd.ExecuteNonQuery();

                message = "Registro de operação efetuado com sucesso";

                conn.disconnect();

            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
        
    }
}
