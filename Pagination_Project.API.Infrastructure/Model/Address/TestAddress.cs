using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class TestAddress
    {
        public Guid AddressID { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid EditedBy { get; set; }
        public DateTime EditedDate { get; set; }
        public bool Active { get; set; }
    }
}
