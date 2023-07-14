using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Model;
using Pagination_Project.API.Domain.Validation;
using Pagination_Project.API.Tests.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pagination_Project.API.Tests.Tests
{
    [Collection("Customer Database")]
    public class Customers
    {
        DatabaseFixture _databaseFixture;
        public Customers(DatabaseFixture _database) {
            _databaseFixture = _database;
        }

        [Fact(DisplayName = "Get Customer Details - Values should be Greater than 0")]
        public void GetCustomerDetails()
        {

            var test = new DatabaseFixture();
            PageFilter pageFilter = new PageFilter()
            {
                pageNumber = 0,
                pageSize = 0
            };

            
            
            var validator = new InputValidations();
            var isvalid = validator.IsValidPayload(pageFilter);

            Assert.False(isvalid, "Validation result -");
            Assert.NotNull(validator.Invalid);
            Assert.Contains("Values should be Greater than 0", validator.Invalid.Value);
        }

        [Fact(DisplayName ="Add Customer - write Data")]
        public void AddCustomer_01()
        {
            //IEnumerable<CustomerForCreationDto> CustomerForCreationDto = new List<CustomerForCreationDto>() { 
            //    new CustomerForCreationDto(){ CustomerName = "UNIT TEST 1", DateOfBirth = DateTime.Now, email = "UNITTEST01@gmail.com" }
            //}.AsEnumerable();

            
            var CustomerForCreationDto =
                new CustomerForCreationDto() { CustomerName = "UNIT TEST 1", DateOfBirth = DateTime.Now, email = "UNITTEST01@gmail.com" };
            
            var customerRes = _databaseFixture._CustomerDataAccess.AddCustomerTest(CustomerForCreationDto);
            var tes = customerRes;
        }
    }
}
