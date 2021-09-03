using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassRegisterProduct
    {

        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();


        //LISTAS E VARIÁVEIS NECESSÁRIAS
        public bool sucessRegistration = false;

        private string message = "";

        public ClassRegisterProduct(string productName, string unity)
        {
            try
            {
                cmd.Connection = conn.connect();
                
                cmd.CommandText = string.Format("INSERT INTO [dbo].[Table] (nome_produto,unidade) VALUES ('{0}','{1}')",productName,unity);
                //System.Diagnostics.Debug.WriteLine(unity);
                
                cmd.ExecuteNonQuery();
                
                message = "Registro efetuado com sucesso";
                sucessRegistration = true;

                conn.disconnect();

                
            
            }
            catch(SqlException e)
            {
                
                sucessRegistration = false;
                message = "Erro ao registrar produto no banco";
                this.message = "Erro ao tentar conectar-se ao banco de dados na classe: " + e;
            }
        }

        public string getMessage()
        {
            return message;
            
        }

        
    }
}
