using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public int TimesBought { get; set; } = 0;
    }
}