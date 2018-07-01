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

        [HttpGet()]
        public IEnumerable<Customer> GetCustomers()
        {
            var query = GetCustomersQuery();
            return Repository.FetchQuery(query);
        }

        private DynamicQuery<Customer> GetCustomersQuery()
        {
            QueryFactory qf = new QueryFactory();
            var query = qf.Customer
                .Select(() => new Customer
                {
                    Id = CustomerFields.Id.ToValue<int>(),
                    Name = CustomerFields.Name.ToValue<string>(),
                    FirstName = CustomerFields.FirstName.ToValue<string>(),
                });
            return query;
        }

        [HttpGet("{customerId:int}")]
        public Customer GetCustomer(int customerId)
        {
            var query = GetCustomersQuery();
            query = query.Where(CustomerFields.Id == customerId);
            return Repository.FetchFirst(query);
        }

        [HttpDelete("{customerId:int}")]
        public void DeleteCustomer(int customerId)
        {
            CustomerEntity customer = Repository.Get<CustomerEntity, int>(customerId);
            Repository.Delete(customer);
        }

        [HttpPost("Save")]
        public void SaveCustomer([FromBody] Customer customer)
        {
            CustomerEntity customerEntity = Repository.Get<CustomerEntity, int>(customer.Id, null, false);
            if(customerEntity == null)
            {
                customerEntity = new CustomerEntity();
            }

            customerEntity.Name = customer.Name;
            customerEntity.FirstName = customer.FirstName;

            Repository.Save(customerEntity);
        }
    }

    public class ControllerEx : Controller
    {
        public IRepository Repository {get; set;}
    }
}
