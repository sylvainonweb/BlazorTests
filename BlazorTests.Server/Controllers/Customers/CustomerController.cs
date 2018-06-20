using BlazorTests.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTests.Server.Entities.EntityClasses;
using BlazorTests.Server.Entities.FactoryClasses;
using BlazorTests.Server.Entities.HelperClasses;
using SD.LLBLGen.Pro.QuerySpec;
using BlazorTests.Common.Technical.Database;

namespace BlazorTests.Server.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerEx
    {
        public CustomerController(IRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Customer> Customers()
        {
            QueryFactory qf = new QueryFactory();
            var query = qf.Customer
                .Select(() => new Customer
                {
                    Id = CustomerFields.Id.ToValue<int>(),
                    Name = CustomerFields.Name.ToValue<string>(),
                    FirstName = CustomerFields.FirstName.ToValue<string>(),
                });

            return Repository.FetchQuery(query);
        }
    }

    public class ControllerEx : Controller
    {
        public IRepository Repository {get; set;}
    }
}
