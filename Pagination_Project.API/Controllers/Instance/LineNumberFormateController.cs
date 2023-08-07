using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Collections.Generic;
using Pagination_Project.API.Domain.Interface;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Enum;

namespace Pagination_Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LineNumberFormateController : BaseController
    {
        private ICustomerDataAccess _icustomerDataAccess;
        public LineNumberFormateController(ICustomerDataAccess customerDataAccess) : base(customerDataAccess)
        {
            _icustomerDataAccess = customerDataAccess;
        }
        [HttpGet("GetLineNumberFormatTemplates")]
        public ActionResult GetLineNumberFormatTemplates([FromQuery] Guid instanceId)
        {
            try
            {
                var lineNumberFormats = _icustomerDataAccess.GetLineNumberFormats(instanceId);
                return StatusCode((int)HttpStatusCode.OK, lineNumberFormats);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("{instanceId}", Name = "AddLineNumberFormate")]
        public ActionResult AddLineNumberFormate(Guid instanceId, [FromBody] IEnumerable<LineNumberFormatCreationDto> lineNumberFormatCreation)
        {
            try
            {
                if (IsValidData(lineNumberFormatCreation, Operations.Create, EntityType.LineNumberFormate, instanceId, out ValidationReturn validation))
                {
                    var lineNumberFormats = _icustomerDataAccess.InsertLineNumberFormate(lineNumberFormatCreation);
                    return StatusCode((int)HttpStatusCode.OK, lineNumberFormats);
                }
                return StatusCode((int)HttpStatusCode.OK, validation);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{instanceId}", Name = "UpdateLineNumberFormate")]
        public ActionResult UpdateLineNumberFormate(Guid instanceId, [FromBody] IEnumerable<LineNumberFormatForUpdateDto> lineNumberFormatForUpdate)
        {
            try
            {
                if (IsValidData(lineNumberFormatForUpdate, Operations.Update, EntityType.LineNumberFormate, instanceId, out ValidationReturn validation))
                {
                    var lineNumberFormats = _icustomerDataAccess.UpdateLineNumberFormate(lineNumberFormatForUpdate);
                    return StatusCode((int)HttpStatusCode.OK, lineNumberFormats);
                }
                return StatusCode((int)HttpStatusCode.OK, validation);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost("AddLineNumberFormatSection")]
        public ActionResult AddLineNumberFormatSection([FromBody] IEnumerable<LineNumberFormatSectionCreationDto> lineNumberFormatSections )
        {
            try
            {
                var lineNumberFormatSection = _icustomerDataAccess.InsertLineNumberFormatSection(lineNumberFormatSections);
                return StatusCode((int)HttpStatusCode.OK, lineNumberFormatSection);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
