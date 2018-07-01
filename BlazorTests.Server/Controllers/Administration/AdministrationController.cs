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
    public class AdministrationController : ControllerEx
    {
        public AdministrationController(IRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet("customerType")]
        public IEnumerable<CustomerType> GetCustomerTypes()
        {
            QueryFactory qf = new QueryFactory();
            var query = qf.CustomerType
                .Select(() => new CustomerType
                {
                    Id = CustomerTypeFields.Id.ToValue<int>(),
                    Text = CustomerTypeFields.Text.ToValue<string>(),
                });
            return Repository.FetchQuery(query);
        }
    }
}
