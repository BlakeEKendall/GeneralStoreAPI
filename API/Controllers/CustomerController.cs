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
    }
}
