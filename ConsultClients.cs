using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ConsultClients
    {
        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();
        private string message = "";

        //listas que irão receber os valores que estão sendo lidos no banco 
        List<int> idList = new List<int>();
        List<string> nameList = new List<string>();
        List<string> dateList = new List<string>();
        List<string> addressList = new List<string>();


        //Arrays que para os quais serão passados os valores das listas
        public string[] names;
        public string[] dates;
        public int[] ids;
        public string[] addresses;

        public ConsultClients()
        {
            //recebe o endereço da conexão com o DB
            cmd.Connection = conn.connect();

            try
            {
                cmd.CommandText = "SELECT * FROM [dbo].[Clientes]";

                SqlDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {
                    idList.Add(int.Parse(Convert.ToString(reader["id"])));
                    nameList.Add(Convert.ToString(reader["nome"]));
                    dateList.Add(Convert.ToString(reader["data_registro"]));
                    addressList.Add(Convert.ToString(reader["endereco"]));

                    
                }


                this.names = nameList.ToArray();
                this.ids = idList.ToArray();
                this.dates = dateList.ToArray();
                this.addresses = addressList.ToArray();

                this.message = "Consulta à tabela de clientes efetuada com sucesso";

                conn.disconnect();
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
