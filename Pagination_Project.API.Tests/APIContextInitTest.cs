using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Pagination_Project.API.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Tests
{
    public class APIContextInitTest
    {
        // to have the same Configuration object as in Startup	
        private readonly IConfigurationRoot _configuration;

        // represents database's configuration
        private readonly DbContextOptions<APIDBContext> _apiDBContext;

        public APIContextInitTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(JSONConfigPath());

            _configuration = builder.Build();
            _apiDBContext = new DbContextOptionsBuilder<APIDBContext>()
               .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
               .Options;

            var test = _apiDBContext;
        }

        public DbContextOptions<APIDBContext> APIDBContext
         => _apiDBContext;
        private string JSONConfigPath()
            => "appsettings.unittest.json";
    }
}
