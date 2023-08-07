using Microsoft.AspNetCore.Mvc;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Enum;
using Pagination_Project.API.Domain.Interface;
using System.Collections.Generic;
using System.Net;

namespace Pagination_Project.API.Controllers.Address
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : BaseController
    {
        public readonly ICustomerDataAccess _customerDataAccess;
        public AddressController(ICustomerDataAccess customerDataAccess) : base(customerDataAccess)
        {
            _customerDataAccess= customerDataAccess;
        }

        [HttpGet(Name = "GetAddresses")]
        public IActionResult GetAddresses()
        {

            var val = new ValidationReturn(500,null,true);

            var adddresses = _customerDataAccess.GetAddresses();
            return Ok(adddresses);
        }

        [HttpPost]
        public IActionResult AddAddress(IEnumerable<AddressCreationDto> address)
        {
            if (IsValidData(address, Operations.Create, EntityType.Address, null, out ValidationReturn validation))
            {
                var testAddress = _customerDataAccess.AddAddresses(address);
                return Ok(testAddress);
            }
            return StatusCode((int)HttpStatusCode.OK, validation);
        }
    }
}
