using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteWebAPI.Models
{
    [Table("Restaurante")] 
    public class Restaurante
    {        
        public int Id { get; set; }
                
        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }               
    }
}
