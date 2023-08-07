using System;
using System.ComponentModel.DataAnnotations;

namespace Pagination_Project.API.Domain.Entities
{
    public class AddressForManipulationDto
    {
        public Guid AddressId { get; set; }

        [StringLength(255)]
        public string Line1 { get; set; }

        [StringLength(255)]
        public string Line2 { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string State { get; set; }

        [StringLength(255)]
        public string Country { get; set; }

        [StringLength(50)]
        public string Zipcode { get; set; }

    }
}
