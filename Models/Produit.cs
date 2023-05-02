using System.ComponentModel.DataAnnotations;

namespace gestion_de_stock.Models
{
    public class Produit
    {
        [Key]
        public  int IdProduit { get; set; }

        public string NomProduit { get; set; }

        public float PrixUnit { get; set; }

        public string Categorie { get; set; }

        public int Quantite { get; set; }
        public ICollection<Commande> commandes { get; set; }

        public static implicit operator Produit(List<Produit> v)
        {
            throw new NotImplementedException();
        }
    }
}
