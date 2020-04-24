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

        [HttpPut]
        public IHttpActionResult UpdateIndividualTransaction([FromUri]int transactionToUpdateId, [FromBody] Transaction updatedTransaction)
        {
            var currentTransaction = _ctx.Transactions.Find(transactionToUpdateId);
            if (currentTransaction == null)
            {
                return BadRequest("The transaction you are looking for does not exist. Please use a valid transaction ID.");
            }
            currentTransaction.ProductId = updatedTransaction.ProductId;
            currentTransaction.CustomerId = updatedTransaction.CustomerId;
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteIndividualTransaction([FromUri] int transactionToDeleteId)
        {
            var transactionToDelete = _ctx.Transactions.Find(transactionToDeleteId);
            if (transactionToDelete == null)
            {
                return BadRequest("The transaction you are looking for does not exist. Please use a valid transaction ID.");
            }
            _ctx.Transactions.Remove(transactionToDelete);
            return Ok();  
        }

    }
}
