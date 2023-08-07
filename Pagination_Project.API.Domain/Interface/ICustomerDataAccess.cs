
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Model;
using System;
using System.Collections.Generic;

namespace Pagination_Project.API.Domain.Interface
{
    public interface ICustomerDataAccess
    {
        #region Address

        IEnumerable<AddressDto> GetAddresses();

        IEnumerable<AddressDto> AddAddresses(IEnumerable<AddressCreationDto> address);

        bool IsAddressExists(IEnumerable<Guid> addressIds);

        #endregion

        #region Customer

        public IEnumerable<CustomerDto> GetCustomerUsingSp();
        IEnumerable<CustomerDto> GetCustomerUsingSpById(int Id, string name);
        IEnumerable<CustomerDto> GetCustomers(PageFilter pageFilter);
        CustomerDto GetCustomer(int customerId);
        bool AddCustomer(IEnumerable<CustomerForCreationDto> customer);
        public bool AddCustomerTest(CustomerForCreationDto customer);
        CustomerDto UpdateCustomer(CustomerForUpdateDto customer);
        bool DeleteCustomer(int customerID);
        bool UpdateCustomerData(CustomerForUpdateDto customer);
        IEnumerable<CustomerDto> UpdateCustomerDataSingle(IEnumerable<CustomerForUpdateDto> customer);

        #endregion

        #region LineNumberFormate
        IEnumerable<LineNumberFormatDto> GetLineNumberFormats(Guid? instanceId = null);
        IEnumerable<LineNumberFormatDto> InsertLineNumberFormate(IEnumerable<LineNumberFormatCreationDto> lineNumberFormatCreation);
        bool UpdateLineNumberFormate(IEnumerable<LineNumberFormatForUpdateDto> lineNumberFormatForUpdates);
        #endregion

        #region LineNumberFormateSection
        IEnumerable<LineNumberFormatSectionDto> InsertLineNumberFormatSection(IEnumerable<LineNumberFormatSectionManipulationDto> lineNumberFormatSections);
        bool UpdateLineNumberFormateSection(IEnumerable<LineNumberFormatSectionManipulationDto> numberFormateSection);

        #endregion LineNumberFormateSection

        #region LineNumbeFormateSectionType

        IEnumerable<LineNumberFormatSectionTypeDto> GetlineNumberFormatSectionType();

        #endregion

        #region SecurityRole

        public IEnumerable<UserSecurityRoleDto> GetUserSecurityRoleTemplate();

        #endregion SecurityRole
    }
}
