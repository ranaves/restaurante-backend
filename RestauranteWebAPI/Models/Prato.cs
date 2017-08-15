using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteWebAPI.Models
{
    [Table("Pratos")]
    public class Prato
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nome { get; set; }

        [Range(0, 99999.99)]
        [Required]
        public float Preco { get; set; }

        [ForeignKey("Restaurante")]
        public int RestauranteId { get; set; }

        public virtual Restaurante Restaurante { get; set; }


    }
}