using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pagination_Project.API.Tests.Setup
{
    [CollectionDefinition("Customer Database")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixture>
    {
    }
}
