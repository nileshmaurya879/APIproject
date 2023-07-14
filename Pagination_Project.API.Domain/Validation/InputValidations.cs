using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Enum;
using Pagination_Project.API.Domain.Helper;
using Pagination_Project.API.Domain.Model;
using System;
using System.Net.Http.Headers;

namespace Pagination_Project.API.Domain.Validation
{
    public class InputValidations
    {
        public InputValidations() { }

        private ValidationReturn _invalid;
        public ValidationReturn  Invalid { get { return _invalid; } }
        public bool IsValid(object data, Operations op, EntityType type, Guid? parentId)
        {
            if (data == null)
                ThrowInvalid(new ValidationReturn() { Value = "test string"});

            PayLoadHandler.justify(data,parentId);

            if(op == Operations.View)
            {
                switch (type)
                {
                    case EntityType.Customer:
                        return IsValidPayload((PageFilter)data);
                }
            }
            return true;
        }

        public bool ThrowInvalid(ValidationReturn value)
        {
            _invalid = value; 
            return false;
        }

        //Customer method
        public bool IsValidPayload(PageFilter data)
        {
            if ((data.pageSize < 0 || data.pageSize == 0) || (data.pageNumber < 0 || data.pageNumber == 0))
                return ThrowInvalid(new ValidationReturn() { Value = "Values should be Greater than 0"});
            return true;
        }

    }
}
