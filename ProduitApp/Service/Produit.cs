using System.ComponentModel.DataAnnotations.Schema;

namespace ProduitApp.Models
{

    /*
     * Ajoutez un modèle à l'application dans le dossier Service. Nommez votre classe Produit.cs. 
     * Cette classe permet de définir l’entité Produit qui est définie par son 
     * identifiant, sa 
     * désignation et 
     * son prix. Toutes les propriétés sont obligatoires. 
     * Le prix doit
        être un double dans l’intervalle [50, 1000000] 
        et la désignation doit être une chaine de
        caractères dont la longueur est dans l’intervalle [5, 25].
     */
    public class Produit
    {
        public Produit(int identifiant, string designation, double prix)
        {
            Identifiant = identifiant;
            Designation = designation;
            Prix = prix;
        }
        public Produit()
        {

        }


        public int Identifiant { get; set; }
        public string Designation { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public double Prix { get; set; }


    }
}
