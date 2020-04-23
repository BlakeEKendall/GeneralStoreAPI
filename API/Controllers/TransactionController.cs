using API.Entities;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class TransactionController : ApiController
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();
        [HttpPost]
        public IHttpActionResult CreateTransaction([FromBody] Transaction transactionToCreate)
        {
            try
            {
                _ctx.Transactions.Add(transactionToCreate);
                _ctx.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.ToString());
            }
            
        }

        [HttpGet]
        public IHttpActionResult GetTransactionList()
        {
            List<TransactionListModel> transactionsToReturn = 
                _ctx.
                Transactions
                .Select(transaction => new TransactionListModel
                {
                    NameOfCustomer = transaction.Customer.Name,
                    ProductDescription = transaction.Product.Description,
                    Total = transaction.TransactionTotal
                })
                .ToList();
            return Ok(transactionsToReturn);
        }

    }
}
