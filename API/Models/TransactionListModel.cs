using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class TransactionListModel
    {
        public string ProductDescription { get; set; }
        public string NameOfCustomer { get; set; }
        public decimal Total { get; set; }
    }
}