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
        public string Nome { get; set; }

        public float Preco { get; set; }

        public int RestauranteId { get; set; }

        [ForeignKey("RestauranteId")]
        public Restaurante Restaurante { get; set; }


    }
}