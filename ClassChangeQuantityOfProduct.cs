using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassChangeQuantityOfProduct
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        string message = "";

        public ClassChangeQuantityOfProduct(int id,int quantity)
        {
            try
            {
                //recebe o endereço da conexão
                cmd.Connection = conn.connect();
                cmd.CommandText = string.Format("UPDATE [dob].[Table] SET [quantidade]={0} WHERE Id={1}", quantity, id);

                cmd.ExecuteNonQuery();

                conn.disconnect();

                this.message = "Alteração da quantidade do produto efetuada com sucesso";

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
