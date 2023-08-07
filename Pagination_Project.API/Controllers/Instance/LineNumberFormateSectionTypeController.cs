using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination_Project.API.Domain.Interface;
using System.Security.Policy;

namespace Pagination_Project.API.Controllers.Instance
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineNumberFormateSectionTypeController : BaseController
    {
        private ICustomerDataAccess _icustomerDataAccess;
        public LineNumberFormateSectionTypeController(ICustomerDataAccess customerDataAccess) : base(customerDataAccess)
        {
            _icustomerDataAccess = customerDataAccess;
        }

        [HttpGet("GetLineFormateSectionType")]
        public IActionResult GetLineFormateSectionType()
        {
            var lineNumberFormateSectionType = _icustomerDataAccess.GetlineNumberFormatSectionType();
            return Ok(lineNumberFormateSectionType);
        }
    }
}
