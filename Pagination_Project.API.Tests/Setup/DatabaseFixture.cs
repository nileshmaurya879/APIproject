using System;
using AutoMapper;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Interface;
using Pagination_Project.API.Infrastructure.Model;
using Pagination_Project.API.Infrastructure.AutoMapper;
using Pagination_Project.API.Infrastructure.Repository;
using System.Linq;

namespace Pagination_Project.API.Tests.Setup
{

    public class DatabaseFixture : IDisposable
    {
        private readonly APIContextInitTest _apiContextInitTest;
        public readonly ICustomerDataAccess _CustomerDataAccess;
        public readonly IMapper _mapper;
        public readonly APIDBContext _aPIDBContext;

        public readonly AddressDto _address;

        public DatabaseFixture() {
            _apiContextInitTest = new APIContextInitTest();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            _mapper = mapperConfig.CreateMapper();
            _CustomerDataAccess = new CustomerDataAccess(new APIDBContext(_apiContextInitTest.APIDBContext), _mapper);

            int id = 41;
            var test = _CustomerDataAccess.GetCustomer(id);

            _address = GetAddress("Unit 45");
        }

        public AddressDto GetAddress(string line1)
        {
            var addressDB = _CustomerDataAccess.GetAddresses();
            var address = addressDB.Where(x => x.Line1 == line1).FirstOrDefault(); 
            return address;
        }
        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
