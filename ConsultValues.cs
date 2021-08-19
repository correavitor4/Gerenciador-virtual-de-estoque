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
        List<int> IdProductList = new List<int>();
        List<string> names = new List<string>();
        List<string> quantidade = new List<string>();
        List<string> unidade = new List<string>();
        List<string> data_criacao = new List<string>();
        public int[] IdProduct;
        public string[] namesAr;
        public string[] quantidadeAr;
        public string[] unidadeAr;
        public string[] data_criacaoAr;



        //Necessário para consulta na tabela operations
        List<int> fkProductList = new List<int>();
        List<string> tipoOperacaoList = new List<string>();
        List<string> descricaoList = new List<string>();
        List<string> dataOperacaoList = new List<string>();
        List<string> relatorioList = new List<string>();
        public int[] fkProduct;
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



            

            //PARÂMETROS
            //cmd.Parameters.AddWithValue("@tabela",nomeTabela);

            //CONECTAR COM O BANCO

            try
            {
                //Recebe o endereço do banco de dados onde quero executar
                cmd.Connection = conn.connect();
                
                

                if (nomeTabela == "Table")
                {
                    //COMANDO SQL
                    cmd.CommandText = String.Format("SELECT * FROM [{0}]", nomeTabela);
                    
                    //Executa comando 
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        IdProductList.Add(int.Parse(Convert.ToString(reader["Id"])));
                        names.Add(Convert.ToString(reader["nome_produto"]));
                        quantidade.Add(Convert.ToString(reader["quantidade"]));
                        data_criacao.Add(Convert.ToString(reader["data_criacao"]));
                        unidade.Add(Convert.ToString(reader["unidade"]));

                    }

                    this.IdProduct = IdProductList.ToArray();
                    this.namesAr = names.ToArray();
                    this.quantidadeAr = quantidade.ToArray();
                    this.unidadeAr = unidade.ToArray();
                    this.data_criacaoAr = data_criacao.ToArray();

                    this.message = "Consulta à tabela de produtos efetuada com sucesso!!";

                }

                else if (nomeTabela == "operations")
                {
                    //COMANDO SQL
                    cmd.CommandText = String.Format("SELECT * FROM [{0}]", nomeTabela);
                    //System.Diagnostics.Debug.WriteLine("Chegou");
                    //Executa comando 
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        fkProductList.Add(int.Parse(Convert.ToString(reader["Id-product"])));
                        tipoOperacaoList.Add(Convert.ToString(reader["tipo-operacao"]));
                        descricaoList.Add(Convert.ToString(reader["descricao"]));
                        dataOperacaoList.Add(Convert.ToString(reader["data-operacao"]));
                        relatorioList.Add(Convert.ToString(reader["relatorio"]));

                        this.fkProduct = fkProductList.ToArray();
                        this.tipoOperacao = tipoOperacaoList.ToArray();
                        this.descricao = descricaoList.ToArray();
                        this.dataOperacao = dataOperacaoList.ToArray();
                        this.relatorio = relatorioList.ToArray();

                    }

                    this.message = "Consulta à tabela de operações efetuada com sucesso!!";


                }




                //desconectar do banco
                conn.disconnect();



                

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
