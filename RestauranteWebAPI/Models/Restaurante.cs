using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteWebAPI.Models
{
    [Table("Restaurantes")]
    public class Restaurante
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
