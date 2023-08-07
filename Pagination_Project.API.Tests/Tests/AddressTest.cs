using Microsoft.VisualStudio.Services.FormInput;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Enum;
using Pagination_Project.API.Domain.Interface;
using Pagination_Project.API.Domain.Validation;
using Pagination_Project.API.Tests.Setup;
using Xunit;

namespace Pagination_Project.API.Tests.Tests
{
    [Collection("Customer Database")]
    public class AddressTest
    {
        DatabaseFixture _databaseFixture;
        public ICustomerDataAccess _customerDataAccess;

        public AddressTest(DatabaseFixture database)
        {
          _databaseFixture = database;
        }

        [Fact(DisplayName = "Add Addresss 01 - Address Already Exists")]
        public void AddAddress_01()
        {
            var addressCreate = new AddressCreationDto()
            {
                AddressId = _databaseFixture._address.AddressId,
                Line1 = "UNIT TEST 1",
                Line2 = "UNIT TEST 1",
                City = "UNIT TEST 1",
                Country = "UNIT TEST 1",
                State = "UNIT TEST 1",
                Zipcode = "123345"
            };

            var validate = new InputValidations(_customerDataAccess);
            bool isValid = validate.IsValid(addressCreate, Operations.Create, EntityType.Address, null);

           Assert.False(isValid);
           

        }

        [Fact(DisplayName = "Test")]
        public void Test()
        {

        }
    }
}
