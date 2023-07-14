using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.Identity;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Enum;
using Pagination_Project.API.Domain.Validation;
using System;

namespace Pagination_Project.API.Controllers
{
    public class BaseController : ControllerBase
    {

        public BaseController() { }

        protected bool IsValidData(object data, Operations op, EntityType type, Guid? instanceId, out ValidationReturn validation)
        {
            var isValid = false;
            var validator = new InputValidations();

            if (validator.IsValid(data, op, type, instanceId))
                isValid = true;

            validation = validator.Invalid;

            return isValid;
        }
        protected bool IsValidData(object data, Operations op, EntityType entity, out ValidationReturn validation)
            => IsValidData(data, op , entity, null, out validation);
        protected bool IsValidData(Operations op, EntityType entity, out ValidationReturn validation)
            => IsValidData(null, op, entity, out validation);
    }
}
