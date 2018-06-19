using BlazorTests.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Server.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Customer> Customers()
        {
            IList<Customer> customers = new List<Customer>();

            for(int i = 0; i <1000; i++)
            {
                customers.Add(new Customer
                {
                    Id = i,
                    Name = "Nom " + i
                });
            }

            return customers;
        }
    }
}
