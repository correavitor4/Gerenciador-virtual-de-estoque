using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    
    public class ConsultValues
    {
        //Necessário para consulta na tabela Table (produtos)
        List<string> names = new List<string>();
        List<string> quantidade = new List<string>();
        List<string> unidade = new List<string>();
        List<string> data_criacao = new List<string>();
        public string[] namesAr;
        public string[] quantidadeAr;
        public string[] unidadeAr;
        public string[] data_criacaoAr;



        //Necessário para consulta na tabela operations
        List<string> tipoOperacaoList = new List<string>();
        List<string> descricaoList = new List<string>();
        List<string> dataOperacaoList = new List<string>();
        List<string> relatorioList = new List<string>();
        public string[] tipoOperacao;
        public string[] descricao;
        public string[] dataOperacao;
        public string[] relatorio;


        ConnectionDB conn = new ConnectionDB();
        //comando em forma de texto
        SqlCommand cmd = new SqlCommand();

        private string message = "";

        public ConsultValues(string nomeTabela)
        {



            //COMANDO SQL
            cmd.CommandText = String.Format("SELECT nome_produto,data_criacao,quantidade,unidade FROM [{0}]", nomeTabela);

            //PARÂMETROS
            //cmd.Parameters.AddWithValue("@tabela",nomeTabela);

            //CONECTAR COM O BANCO

            try
            {
                //Recebe o endereço do banco de dados onde quero executar
                cmd.Connection = conn.connect();
                //executar comando
                SqlDataReader reader = cmd.ExecuteReader();

                if (nomeTabela == "Table")
                {
                    //salva em um array
                    while (reader.Read())
                    {
                        names.Add(Convert.ToString(reader["nome_produto"]));
                        quantidade.Add(Convert.ToString(reader["quantidade"]));
                        data_criacao.Add(Convert.ToString(reader["data_criacao"]));
                        unidade.Add(Convert.ToString(reader["unidade"]));

                    }

                    this.namesAr = names.ToArray();
                    this.quantidadeAr = quantidade.ToArray();
                    this.unidadeAr = unidade.ToArray();
                    this.data_criacaoAr = data_criacao.ToArray();

                }
                else if (nomeTabela == "operations")
                {

                }




                //desconectar do banco
                conn.disconnect();



                this.message = "Consulta ao banco efetuada com sucesso!!";

            }

            catch (SqlException e)
            {
                this.message = "Erro ao tentar de conectar ao banco de dados: " + e;
            }
        }

        public string getMessage()
        {
            return this.message;
        }
    };
       


    
}
