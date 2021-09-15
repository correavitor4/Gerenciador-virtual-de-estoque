using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gerenciador_vitural_de_estoque
{
    class ClassConsultSales
    {

        List<int> idList = new List<int>();
        List<string> productsSoldList = new List<string>();
        List<string> productsSoldIdList = new List<string>();
        List<string> productsSoldQuantityList = new List<string>();
        List<string> productsSoldUnityList = new List<string>();
        List<string> dataList = new List<string>();
        List<string> clientIdList= new List<string>();
        List<string> productsSoldIndividualPriceList = new List<string>();
        public int[] id;
        public string[] productsSold;
        public string[] productsSoldId;
        public string[] productsSoldUnity;
        public string[] productsSoldQuantity;
        public string[] data;
        public string[] clientId;
        public string[] productsSoldIndividualPrice;


        ConnectionDB conn = new ConnectionDB();
        SqlCommand cmd = new SqlCommand();

        private string message = "";

        public ClassConsultSales()
        {
            try
            {
                cmd.Connection = conn.connect();

                cmd.CommandText = "SELECT * FROM [dbo].[Vendas]";

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    this.idList.Add(int.Parse(Convert.ToString(reader["Id"])));
                    this.productsSoldList.Add(reader["produtos_vendidos"].ToString());
                    this.productsSoldIdList.Add(reader["produtos_vendidos_id"].ToString());
                    this.productsSoldQuantityList.Add(reader["produtos_vendidos_quantidade"].ToString());
                    this.productsSoldUnityList.Add(reader["produtos_vendidos_unidade"].ToString());
                    this.dataList.Add(reader["data"].ToString());
                    this.clientIdList.Add(reader["id_cliente"].ToString());
                    this.productsSoldIndividualPriceList.Add(reader["preco_individual_produto"].ToString());
                }

                this.id = idList.ToArray();
                this.productsSold = productsSoldList.ToArray();
                this.productsSoldId = productsSoldIdList.ToArray();
                this.productsSoldQuantity = productsSoldQuantityList.ToArray();
                this.productsSoldUnity = productsSoldUnityList.ToArray();
                this.data = dataList.ToArray();
                this.clientId = clientIdList.ToArray();
                this.productsSoldIndividualPrice = productsSoldIndividualPriceList.ToArray();

                this.message = "Consulta à tabela de Vendas executada com sucesso";
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
