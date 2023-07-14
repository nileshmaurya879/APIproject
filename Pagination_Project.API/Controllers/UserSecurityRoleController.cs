using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination_Project.API.Domain.Interface;

namespace Pagination_Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSecurityRoleController : ControllerBase
    {
        private readonly ICustomerDataAccess _customerDataAccess;
        public UserSecurityRoleController(ICustomerDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        [HttpGet("GetTemplate")]
        public ActionResult GetTemplates()
        {
            var data = _customerDataAccess.GetUserSecurityRoleTemplate();
            return Ok(data);
        }
    }
}
