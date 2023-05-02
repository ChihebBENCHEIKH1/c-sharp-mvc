using System.ComponentModel.DataAnnotations;

namespace gestion_de_stock.Models
{
    public class Commande
    {
        [Key]
        public int Id { get; set; }
        public int idClient { get; set; }
        public int idProduit { get; set; }
        public DateTime dateCommande { get; set; }
        public long quantiteDemandee { get; set; }

        public long prix { get; set; }
        public Client client { get; set; }
        public Produit Produit { get; set; }
    }
}