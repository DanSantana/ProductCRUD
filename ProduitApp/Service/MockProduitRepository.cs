using ProduitApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProduitApp.Service
{
    public class MockProduitRepository : IProduitService
    {
        IEnumerable<Produit> produits;
        public MockProduitRepository()
        {
            produits = new List<Produit>
            {
               //new Produit{ Identifiant=1, Designation="Ordinateurs", Prix=2400.50},
               // new Produit{ Identifiant=2, Designation="Imprimante", Prix=200.20},
               // new Produit { Identifiant = 1, Designation = "Scanner", Prix = 58.45 }
            };   
        }


        public void Add(Produit produit)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Produit> AllProducts()
        {
            return produits;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Produit GetProductById(int id)
        {
            Produit prod = produits.FirstOrDefault(p => p.Identifiant.Equals(id));
            return prod;

        }

        public void Edit(Produit model)
        {
            throw new System.NotImplementedException();
        }
    }
}
