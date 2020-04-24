using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int TimesOrdered { get; set; } = 0;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}