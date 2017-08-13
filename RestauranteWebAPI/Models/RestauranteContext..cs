using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RestauranteWebAPI.Models
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext() : base("Restaurante")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }
    }
}