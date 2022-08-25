using DocumentFormat.OpenXml.CustomProperties;
using ProduitApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProduitApp.Service
{

    public class ProduitRepository : IProduitService
    {
        /*
      ADO
     Connecting
     Command
     Data Reader
     Data Adapter
     Data set

      */

        private readonly string connectionString = "Integrated Security=SSPI;Persist Security Info=False;" +
            "Initial Catalog=ProduitApp;Data Source=DESKTOP-BH3CB2F\\BDDNN001" ;
     
        SqlConnection connection;


        public ProduitRepository()
        {
            

        }

        public void Add(Produit produit)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produit> AllProducts()
        {
            List<Produit> products = new List<Produit>();

            products = ListProds();
            return products;
        }


        public void Delete(int id)
        {
           OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", connection);

            // creat a command builder
            SqlCommandBuilder thisCommand = new SqlCommandBuilder(adapter);
            // dataset
            DataSet prodDataSet = new DataSet();
            adapter.Fill(prodDataSet, "Products");

            // set key
            DataColumn[] key = new DataColumn[1];
            key[0] = prodDataSet.Tables["Products"].Columns["id"];
            prodDataSet.Tables["Products"].PrimaryKey = key;

            DataRow findRow = prodDataSet.Tables["Products"].Rows.Find(id);

            if (findRow != null)
            {
                findRow.Delete();
                adapter.Update(prodDataSet, "Products");

            }
           connection.Close();

        }

        public void Edit(Produit model)
        {
            throw new System.NotImplementedException();
        }

        public Produit GetProductById(int id)
        {
            Produit produit = new Produit();
            OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", connection);

            // creat a command builder
            SqlCommandBuilder thisCommand = new SqlCommandBuilder(adapter);
            // dataset
            DataSet prodDataSet = new DataSet();
            adapter.Fill(prodDataSet, "Products");

            // set key
            DataColumn[] key = new DataColumn[1];
            key[0] = prodDataSet.Tables["Products"].Columns["id"];
            prodDataSet.Tables["Products"].PrimaryKey = key;

            DataRow findRow = prodDataSet.Tables["Products"].Rows.Find(id);

            if (findRow != null)
            {
                produit = ProcessDTO(findRow);
            }
            connection.Close();

            return produit;
        }

        private Produit ProcessDTO(DataRow findRow)=>      
            new Produit((int)findRow["id"], findRow["designation"].ToString(), System.Convert.ToDouble(findRow["prix"]));
      
     

        public List<Produit> ListProds()
        {
            List<Produit> products = new List<Produit>();

            OpenConnection();
            SqlCommand command = CreatCommant("SELECT * FROM Products");

            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Produit((int)reader["id"], reader["designation"].ToString(), System.Convert.ToDouble(reader["prix"])));
            }
            reader.Close();
            connection.Close();

            return products;
        }

        private static SqlCommand CreatCommant(string Commandtxt)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = Commandtxt;
            command.CommandType = CommandType.Text;
            return command;
        }

        private void OpenConnection()
        {
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
        }
    }
}
