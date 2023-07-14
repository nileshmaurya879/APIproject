using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Infrastructure.Model
{
    [Keyless]
    public class spCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; }
    }
}
