using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassEditProduct
    {

        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();

        private string message = "";
        public ClassEditProduct(string id, string name, string unity)
        {

            try
            {
                //Recebe o endereço do banco de dados
                cmd.Connection = conn.connect();

                //Comando que será executado
                cmd.CommandText = string.Format("UPDATE [dbo].[Table] SET nome_produto='{0}',unidade='{1}' WHERE id={2}", name, unity, id);

                //executa o comando
                cmd.ExecuteNonQuery();

                message = "Edição efetudada com sucesso";

                conn.disconnect();

            }
            catch (SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                this.message = "Erro ao se conectar ao banco";
            }

        }

        public string getMessage()
        {
            return this.message;
        }
    }
}
