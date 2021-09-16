using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassDeleteSale
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();

        private string message = "";

        public ClassDeleteSale(int saleId)
        {
            
            try
            {
                System.Diagnostics.Debug.WriteLine(saleId);
                cmd.Connection = conn.connect();
                cmd.CommandText = string.Format("DELETE FROM [dbo].[Vendas] WHERE [Id]='{0}'",saleId);

                cmd.ExecuteNonQuery();

                this.message = "Venda excluída com sucesso";
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
