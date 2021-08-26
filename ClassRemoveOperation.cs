using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassRemoveOperation
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();

        private string message = "";
        public ClassRemoveOperation(int IdProduct)
        {
            

            try
            {
                //Recebe o endereço da conexão
                cmd.Connection = conn.connect();
                cmd.CommandText = string.Format("DELETE FROM [dbo].[operations] WHERE [Id-product]='{0}'",IdProduct);

                cmd.ExecuteNonQuery();


                this.message = "As antigas operações com o produto foram devidamente removidas";
                conn.disconnect();

            }catch(Exception e)
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
