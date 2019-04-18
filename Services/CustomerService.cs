using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    public class CustomerService
    {
        public Task<Customer[]> GetCustomersAsync()
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Customer
            {
                Id = index,
                FirstName = "Pr�nom " + index,
                LastName = "Nom " + index
            }).ToArray());
        }
    }
}
