using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities
{
    public class AddressForUpdate : AddressForManipulationDto
    {
        public AddressDto Current { get; set; }

        public bool Update
        {
            get
            {
                // update and existing address
                if (Current != null)
                {
                    return Current.AddressId != AddressId ||
                           Current.Line1 != Line1 ||
                           Current.Line2 != Line2 ||
                           Current.City != City ||
                           Current.State != State ||
                           Current.Country != Country ||
                           Current.Zipcode != Zipcode;
                }

                return false;
            }
        }
    }
}
