using AutoMapper;
using Pagination_Project.API.Domain.Interface;
using Pagination_Project.API.Infrastructure.AutoMapper;
using Pagination_Project.API.Infrastructure.Model;
using Pagination_Project.API.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Tests.Setup
{

    public class DatabaseFixture : IDisposable
    {
        private readonly APIContextInitTest _apiContextInitTest;
        public readonly ICustomerDataAccess _CustomerDataAccess;
        public readonly IMapper _mapper;
        public readonly APIDBContext _aPIDBContext;
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
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
