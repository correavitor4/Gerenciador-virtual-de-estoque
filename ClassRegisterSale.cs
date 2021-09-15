using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassRegisterSale
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();

        private string message = "";

        public ClassRegisterSale(string nomeCliente,string produtosVendidos,string produtosVendidosId,string produtosVendidosQuantidade,string produtosVendidosUnidade,int idCliente)
        {

            try
            {
                //RECEBE O ENDEREÇO DA CONEXÃO
                cmd.Connection = conn.connect();
                cmd.CommandText = string.Format("INSERT INTO [dbo].[Vendas] (nome_cliente,produtos_vendidos,produtos_vendidos_id,id_cliente,produtos_vendidos_quantidade,produtos_vendidos_unidade) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", nomeCliente, produtosVendidos, produtosVendidosId, idCliente,produtosVendidosQuantidade,produtosVendidosUnidade);

                cmd.ExecuteNonQuery();

                conn.disconnect();

                this.message = "A venda foi cadastrada com sucesso";
            }
            catch(SqlException e)
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
