using System.ComponentModel.DataAnnotations;

namespace gestion_de_stock.Models
{
    public class Admin:Personne
    {
        [Key]
        public int id { get; set; }
    }
}
