using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteWebAPI.Models
{
    [Table("Prato")]    
    public class Prato
    {
        public int Id { get; set; }
                
        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }
                
        [Range(0, 99999.99)]
        [Required]
        public float Preco { get; set; }

        public int RestauranteId { get; set; }

        [ForeignKey("RestauranteId")]
        public Restaurante Restaurante { get; set; }

    }
}