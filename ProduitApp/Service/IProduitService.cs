using ProduitApp.Models;
using System.Collections;
using System.Collections.Generic;

namespace ProduitApp.Service
{
    public interface IProduitService
    {
        // Afficher tous les produits.
        public IEnumerable<Produit> AllProducts();

        // Afficher les détails d’un produit.
        public Produit GetProductById(int id);

        // Saisir et ajouter un nouveau produit.
        public void Add(Produit produit);
        // Éditer et modifier un produit.

        public void Edit(Produit model);
        // Supprimer un produit.
        public void Delete(int id);
    }
}
