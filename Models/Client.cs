using System.ComponentModel.DataAnnotations;

namespace gestion_de_stock.Models
{
    public class Client :Personne
    {
        [Key]
        public  int IdClient { get; set; }

        public string Addresse { get; set; }
        public ICollection<Commande> commandes { get; set; }
    }
}
