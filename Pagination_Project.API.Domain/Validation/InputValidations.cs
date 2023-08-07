using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Enum;
using Pagination_Project.API.Domain.Helper;
using Pagination_Project.API.Domain.Helper.Message;
using Pagination_Project.API.Domain.Interface;
using Pagination_Project.API.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Pagination_Project.API.Domain.Validation
{
    public class InputValidations
    {
        public ICustomerDataAccess _customerDataAccess;
        public InputValidations(ICustomerDataAccess customerDataAccess) {
            _customerDataAccess = customerDataAccess;
        }

        private ValidationReturn _invalid;
        public ValidationReturn  Invalid { get { return _invalid; } }
        public bool IsValid(object data, Operations op, EntityType type, Guid? parentId)
        {
            if (data == null)
                ThrowInvalid(new ValidationReturn() { Message = "test string"});

            PayLoadHandler.justify(data,parentId);

            if(op == Operations.View)
            {
                switch (type)
                {
                    case EntityType.Customer:
                        return IsValidPayload((PageFilter)data);
                    case EntityType.Address:
                        {
                            if (data is IList<AddressCreationDto> AddressCreation)
                                return IsValidAddress(AddressCreation, op);
                            break;
                        }
                }
            }else if(op == Operations.Create)
            {
                switch (type)
                {
                   
                    case EntityType.Address:
                        {
                            if(data is IList<AddressCreationDto> AddressCreation)
                                return IsValidAddress(AddressCreation, op);
                            break;
                        }
                      
                }
            }
            return true;
        }

        public bool ThrowInvalid(ValidationReturn value)
        {
            _invalid = value; 
            return false;
        }


        #region Custome Method


        //Customer
        public bool IsValidPayload(PageFilter data)
        {
            if ((data.pageSize < 0 || data.pageSize == 0) || (data.pageNumber < 0 || data.pageNumber == 0))
                return ThrowInvalid(new ValidationReturn() { Message = "Values should be Greater than 0" });
            return true;
        }


        // Adddress

        public bool IsValidAddress(IEnumerable<AddressCreationDto> addressCreation, Operations op)
        {

            if(op == Operations.Create)
            {
                if (_customerDataAccess.IsAddressExists(addressCreation.Select(x=>x.AddressId)))
                    ThrowInvalid(MessageValidatorHelper.ToInputValidationResult(MessgageValidationType.AlreadyExists, EntityType.Address));
            }
            return true;
        }

        #endregion






    }
}
