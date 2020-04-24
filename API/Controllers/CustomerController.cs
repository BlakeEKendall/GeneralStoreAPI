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
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _ctx = new ApplicationDbContext();


        [HttpPost]
        public IHttpActionResult CreateCustomer ([FromBody] Customer customerToCreate)
        {
            _ctx.Customers.Add(customerToCreate);
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllCustomers()
        {
            return Ok(_ctx.Customers.ToList());
        }

        [HttpGet]
        public IHttpActionResult GetIndividualCustomer(int customerId)
        {
            var customerToReturn = _ctx.Customers.Find(customerId);
            if(customerToReturn == null)
            {
                return BadRequest("The customer you are looking for does not exist.");
            }
            return Ok(customerToReturn);
        }

        [HttpPut]
        public IHttpActionResult UpdateIndividualCustomer([FromUri]int customerToUpdateId, [FromBody] Customer updatedCustomer)
        {
            var currentCustomer = _ctx.Customers.Find(customerToUpdateId);
            if(currentCustomer == null)
            {
                return BadRequest("The customer you are looking for does not exist. Please use a valid customer ID.");
            }
            currentCustomer.Name = updatedCustomer.Name;
            currentCustomer.TimesOrdered = updatedCustomer.TimesOrdered;
            _ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteIndividualCustomer([FromUri] int customerToDeleteId)
        {
            var customerToDelete = _ctx.Customers.Find(customerToDeleteId);
            if(customerToDelete == null)
            {
                return BadRequest("The customer you are looking for does not exist. Please use a valid customer ID.");
            }
            _ctx.Customers.Remove(customerToDelete);
            return Ok();
        }
    }
}
