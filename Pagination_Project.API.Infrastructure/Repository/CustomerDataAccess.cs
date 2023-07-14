using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi.Exceptions;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Helper;
using Pagination_Project.API.Domain.Interface;
using Pagination_Project.API.Domain.Model;
using Pagination_Project.API.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Pagination_Project.API.Infrastructure.Repository
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private readonly APIDBContext _APIDBContext;

        private IMapper _mapper { get; }
        public CustomerDataAccess(APIDBContext aPIDBContext, IMapper mapper) { 
        
            _APIDBContext= aPIDBContext;
            _mapper = mapper;
        }

        #region Customer

        public IEnumerable<CustomerDto> GetCustomerUsingSp()
        {
            var query = "exec [dbo].[spTest]";
            var values = _APIDBContext.spCustomers.FromSqlRaw(query).ToList();
            return  _mapper.Map<IEnumerable<CustomerDto>>(values);
        }

        public IEnumerable<CustomerDto> GetCustomerUsingSpById(int Id, string name)
        {
            var paramList = new List<SqlParameter>();

            paramList.Add(new SqlParameter("@id", System.Data.SqlDbType.Int)
            {
                IsNullable = true,
                Value = Id
            });
            paramList.Add(new SqlParameter("@name", System.Data.SqlDbType.NVarChar,255)
            {
                IsNullable = true,
                Value = name
            });

            var query = "exec [dbo].[spGetCustomerById] @id, @name";

            var values = _APIDBContext.spCustomers.FromSqlRaw(query, paramList.ToArray());

            return _mapper.Map<IEnumerable<CustomerDto>>(values);
        }
        public IEnumerable<CustomerDto> GetCustomers(PageFilter pageFilter)
        {
            var customerse = _APIDBContext.Customers.Where(x=>x.Active).Skip((pageFilter.pageNumber - 1) * pageFilter.pageSize).Take(pageFilter.pageSize).ToList();

            var values = _mapper.Map<IEnumerable<CustomerDto>>(customerse);
            return values;
        }

        public CustomerDto GetCustomer(int customerId)
        {
            var existCustomer = _APIDBContext.Customers.Where(x => x.Active && x.CustomerId == customerId).FirstOrDefault();

            var customer = _mapper.Map<CustomerDto>(existCustomer);

            return customer;
        }

        public bool AddCustomer(IEnumerable<CustomerForCreationDto> customer)
        {
                
            var custValues = _mapper.Map<IEnumerable<Customer>>(customer);

            custValues.ToList().ForEach(x =>
            {
                x.Active = true;
            });
            
            _APIDBContext.Customers.AddRange(custValues);
            _APIDBContext.SaveChanges();
            return true;
        }

        public bool AddCustomerTest(CustomerForCreationDto customer)
        {
            var cust = new Customer()
            {
                CustomerName = customer.CustomerName,
                DateOfBirth = customer.DateOfBirth,
                Active= true,
            };
           // var custValues = _mapper.Map<Customer>(customer);

            _APIDBContext.Customers.Add(cust);
            _APIDBContext.SaveChanges();
            return true;
        }

        public CustomerDto UpdateCustomer(CustomerForUpdateDto customer)
        {
            //_APIDBContext.Customers.Update(customer);
            _APIDBContext.SaveChanges();
            return null;
        }

        public bool DeleteCustomer(int customerID) {
            var values = _APIDBContext.Customers.Find(customerID);
            if(values != null)
            {
                _APIDBContext.Entry(values).State = EntityState.Deleted;
                _APIDBContext.SaveChanges();
                return true; 
            }
            return false;
        }

        public bool UpdateCustomerData(CustomerForUpdateDto customer)
        {
            if(customer != null)
            {
                //if(customer.CustomerId == 0)
                //{
                //    var addCustomer = _mapper.Map<Customer>(customer);
                //    _APIDBContext.Customers.Add(addCustomer);
                //}
                
                if(customer.CustomerId > 0) {

                    var customerData = _APIDBContext.Customers.Where(x => x.Active && x.CustomerId == customer.CustomerId).FirstOrDefault();

                    if (customerData != null && customer.update)
                    {
                        customerData.CustomerName = customer.CustomerName;
                        customerData.email = customer.Email;
                        customerData.DateOfBirth = customer.DateOfBirth;
                        _APIDBContext.SaveChanges();
                    }
                    //if(customer.Active == false) {
                    //    customerData.Active = false;
                    //}
                }
                return true;
            }
            return false;
        }

        public IEnumerable<CustomerDto> UpdateCustomerDataSingle(IEnumerable<CustomerForUpdateDto> customer)
        {
            if(customer != null)
            {

                //update customer
                var customerDB = GetCustomerFromDatabase(customer.Where(x => x.CustomerId != 0).Select(x => x.CustomerId));
                var existitem = _mapper.Map<IEnumerable<CustomerDto>>(customerDB);

                customer.ToList().ForEach(x =>
                {
                    x.Current = x.Current == null && existitem.Any(y => y.CustomerId == x.CustomerId) ? existitem.Single(y => y.CustomerId == x.CustomerId) : x.Current;
                });

                var customerUpdate = customer.Where(x => x.update).ToList();
                var save = customerUpdate.Any();

             
                //add customer
                var addNewCustomer = customer.Where(x=>x.CustomerId == 0).ToList();

                var newCustomer = _mapper.Map<IEnumerable<CustomerForCreationDto>>(addNewCustomer);
              if(newCustomer != null && newCustomer.Count() > 0) 
                     AddCustomer(newCustomer);

                //delete customer
                var deleteCustomer = customer.Where(x=>x.CustomerId != 0 && x.Active == false).Select(x=>x.CustomerId).ToList();
                if(deleteCustomer != null && deleteCustomer.Count() > 0)
                    DeleteCustomerData(deleteCustomer);

                // update customer
                var updatecustomer = customerUpdate.Where(x => x.exist && x.Active).Select(x => x.CustomerId);


                if (updatecustomer.Any())
                {
                    customerDB.Where(x => updatecustomer.Contains(x.CustomerId)).ToList().ForEach(x =>
                    {
                        x = _mapper.Map(customer.Single(y => y.CustomerId == x.CustomerId),x);
                    });
                }

                if(save)
                    _APIDBContext.SaveChanges();

            }
            var values = _mapper.Map<IEnumerable<CustomerDto>>(customer);
            return values;
        }

        public bool DeleteCustomerData(IEnumerable<int> Customer)
        {
            var customerDBs = GetCustomerFromDatabase(Customer);
            customerDBs.ToList().ForEach(x =>
            {
                x.Active = false;
            });

            _APIDBContext.SaveChanges();
            return true;
        }

        public IEnumerable<Customer> GetCustomerFromDatabase(IEnumerable<int> Customer)
        {
            var custData = _APIDBContext.Customers.Where(x=> Customer.Contains(x.CustomerId));
            return custData.ToList();
        }

        #endregion

        #region LineNumberFormate

        public IEnumerable<TblLineNumberFormat> GetLineNumberFormatFromDatabase(IEnumerable<Guid> lineNumberFormateIds, bool includeSection = false)
        {
            var lineNumberFormats = _APIDBContext.TblLineNumberFormats
                                    .Where(x => lineNumberFormateIds.Contains(x.LineNumberFormatId) && x.Active);

            if (includeSection)
                lineNumberFormats = lineNumberFormats.Include(y => y.TblLineNumberFormatSections);

            return lineNumberFormats.ToList();
        }
        public IEnumerable<LineNumberFormatDto> GetLineNumberFormats(Guid? instanceId = null)
        {
            var lineNumberFormats = _APIDBContext.TblLineNumberFormats
                .AsNoTracking()
                .Include(y => y.Instance)
                .Include(x => x.TblLineNumberFormatSections
                    .Where(x => x.Active)
                    .OrderBy(x => x.Index))
                    .ThenInclude(x => x.LineNumberFormatSectionType)
                .Where(x => x.InstanceId == instanceId && x.Active);

            var test = lineNumberFormats.ToList();

            return _mapper.Map<IEnumerable<LineNumberFormatDto>>(lineNumberFormats.OrderBy(x => x.Name));
        }

        public IEnumerable<LineNumberFormatDto> InsertLineNumberFormate(IEnumerable<LineNumberFormatCreationDto> lineNumberFormatCreation)
        {
            if (lineNumberFormatCreation == null)
                throw new ArgumentNullException(nameof(lineNumberFormatCreation));
            try
            {
                var createdBy = Guid.NewGuid();
                var now = DateTime.UtcNow;
                var lineNumberFormateDB = _mapper.Map<IEnumerable<TblLineNumberFormat>>(lineNumberFormatCreation);

                lineNumberFormateDB.ForEach(x => {
                    x.CreatedDate = now;
                    x.CreatedBy = createdBy;
                    x.EditedDate = now;
                    x.EditedBy = createdBy;
                    x.Active = true;
                });

                _APIDBContext.TblLineNumberFormats.AddRange(lineNumberFormateDB);

                if (lineNumberFormatCreation != null && lineNumberFormatCreation.Any())
                    InsertLineNumberFormatSection(lineNumberFormatCreation.Where(x => x.Sections != null && x.Sections.Any()).SelectMany(x => x.Sections));

                //_APIDBContext.SaveChanges();

                return _mapper.Map<IEnumerable<LineNumberFormatDto>>(lineNumberFormateDB);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public bool UpdateLineNumberFormate(IEnumerable<LineNumberFormatForUpdateDto> lineNumberFormats)
        {
            if (lineNumberFormats == null)
                throw new ArgumentNullException(nameof(lineNumberFormats));

            // retrieve line number formate when we have pass the existing record id from database
            var lineNumberFormateDB = GetLineNumberFormatFromDatabase(lineNumberFormats.Where(x => x.LineNumberFormatId.HasValue).Select(y => y.LineNumberFormatId.Value));

            // set current line number formate so that a comparison can be made to evaluate if a line number formate save required or not
            _ = lineNumberFormats.Select(x =>
            {
                x.LineNumberFormatId ??= Guid.NewGuid();
                x.Current = x.Current == null && lineNumberFormateDB.Any(y => y.LineNumberFormatId == x.LineNumberFormatId) ? _mapper.Map<LineNumberFormatDto>(lineNumberFormateDB.Single(y => y.LineNumberFormatId == x.LineNumberFormatId)) : x.Current;
                return x;
            }).ToList();

            var save = false;

            var lineNumberFormateNew = lineNumberFormats.Where(x => !x.Exists);
            if (lineNumberFormateNew.Any())
            {
                InsertLineNumberFormate(_mapper.Map<IEnumerable<LineNumberFormatCreationDto>>(lineNumberFormateNew));
                save = true;
            }

            // updating existing line Number formate
            var createdBy = Guid.NewGuid();
            var now = DateTime.UtcNow;

            var lineNumberFormatesExisting = lineNumberFormats.Where(x => x.Exists);
            if (lineNumberFormatesExisting.Any())
            {
                var linenumberformateupdate = lineNumberFormatesExisting.Where(x => x.Update && x.Active).Select(x => x.LineNumberFormatId);
                if (linenumberformateupdate.Any())
                {
                    _ = lineNumberFormateDB.Where(x => linenumberformateupdate.Contains(x.LineNumberFormatId)).Select(x =>
                    {
                        x = _mapper.Map(lineNumberFormatesExisting.Single(y => y.LineNumberFormatId == x.LineNumberFormatId), x);
                        x.EditedBy = createdBy;
                        x.EditedDate = now;
                        return x;
                    }).ToList();
                    save = true;
                }
                //Delete line number formate section
                var lineNumberFormateSectionIdsDelete = lineNumberFormatesExisting.Where(x => x.Update && !x.Active).Select(x => x.LineNumberFormatId.Value);
                if (lineNumberFormateSectionIdsDelete.Any())
                {
                    DeleteLineNumberFormate(lineNumberFormateSectionIdsDelete);
                    save = true;
                }
                //Update line Number Formate section
                if (UpdateLineNumberFormateSection(lineNumberFormatesExisting.Where(x => x.Active).SelectMany(x => x.Sections)))
                    save = true;
            }

           if (save)
                _APIDBContext.SaveChanges();
            return true;
        }

        public bool DeleteLineNumberFormate(IEnumerable<Guid> lineNumberFormateIds)
        {
            if (lineNumberFormateIds == null)
                return false;

            var lineNumberFormateDBs = GetLineNumberFormatFromDatabase(lineNumberFormateIds, true);
            if(lineNumberFormateDBs != null)
            {
                var lineNumberFormateSectionIds = lineNumberFormateDBs.SelectMany(x=> x.TblLineNumberFormatSections).Select(y=> y.LineNumberFormatSectionId);
                lineNumberFormateDBs.ToList().ForEach(y =>
                {
                    y.Active = false;
                });
                //delete line number formate section
                if (lineNumberFormateSectionIds.Any())
                    DeleteLineNumberFormateSection(lineNumberFormateSectionIds);
            }
            return true;
        }
        #endregion

        #region  LineNumberFormateSection

        public IEnumerable<TblLineNumberFormatSection> GetNumberFormatSectionsFromDatabase(IEnumerable<Guid> lineNumberFormateSectionIds, bool inludeTypes = false)
        {
            var lineNumberFormateSections = _APIDBContext.TblLineNumberFormatSections.Where(x => lineNumberFormateSectionIds.Contains(x.LineNumberFormatSectionId) && x.Active);

            if (inludeTypes)
                lineNumberFormateSections.Include(y => y.LineNumberFormatSectionType);

            return lineNumberFormateSections.ToList();
        }
        public IEnumerable<LineNumberFormatSectionDto> InsertLineNumberFormatSection(IEnumerable<LineNumberFormatSectionManipulationDto> lineNumberFormatSections)
        {
            if (lineNumberFormatSections == null)
                throw new ArgumentNullException(nameof(lineNumberFormatSections));
            try
            {
                var createdBy = Guid.NewGuid();
                var now = DateTime.UtcNow;

                var lineNumberFormateSectionDB = _mapper.Map<IEnumerable<TblLineNumberFormatSection>>(lineNumberFormatSections);

                lineNumberFormateSectionDB.ForEach(x =>
                {
                    x.CreatedDate = now;
                    x.CreatedBy = createdBy;
                    x.EditedDate = now;
                    x.EditedBy = createdBy;
                    x.Active = true;
                });

                _APIDBContext.TblLineNumberFormatSections.AddRange(lineNumberFormateSectionDB);

                return _mapper.Map<IEnumerable<LineNumberFormatSectionDto>>(lineNumberFormateSectionDB);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateLineNumberFormateSection(IEnumerable<LineNumberFormatSectionManipulationDto> numberFormateSection)
        {
            if (numberFormateSection == null)
                throw new ArgumentNullException(nameof(numberFormateSection));

            // retrieve line number formate section when we have pass existing id's
            var lineNumberFormateSectionDB = GetNumberFormatSectionsFromDatabase(numberFormateSection.Where(x=> x.LineNumberFormatSectionId.HasValue).Select(y=> y.LineNumberFormatSectionId.Value));

            // set current line number formate section to evaluate that formate section need update or not
            _ = numberFormateSection.Select(x =>
            {
                x.LineNumberFormatSectionId ??= Guid.NewGuid();
                x.Current = x.Current == null && lineNumberFormateSectionDB.Any(y => y.LineNumberFormatSectionId == x.LineNumberFormatSectionId) ? _mapper.Map<LineNumberFormatSectionDto>(lineNumberFormateSectionDB.Single(y => y.LineNumberFormatSectionId == x.LineNumberFormatSectionId)) : x.Current;
                return x;
            }).ToList();


            var save = false;
            var createdBy = Guid.NewGuid();
            var CreatedBy = DateTime.UtcNow;

            //Insert new line number formate section 
            var lineNumberFormateSectionNew = numberFormateSection.Where(x => !x.Exists);
            if (lineNumberFormateSectionNew.Any())
            {
                InsertLineNumberFormatSection(lineNumberFormateSectionNew);
                save = true;
            }

            //Update existing line formate section 
            var lineNumberFormateSectionExisting = numberFormateSection.Where(x => x.Exists);
            if (lineNumberFormateSectionExisting.Any())
            {
                var lineNumberFormateIdsUpdate = lineNumberFormateSectionExisting.Where(x => x.Update && x.Active).Select(y => y.LineNumberFormatSectionId);
                if (lineNumberFormateIdsUpdate.Any())
                {
                    _ = lineNumberFormateSectionDB.Where(x => lineNumberFormateIdsUpdate.Contains(x.LineNumberFormatSectionId)).Select(x =>
                    {
                        x = _mapper.Map(lineNumberFormateSectionExisting.Single(y => y.LineNumberFormatSectionId == x.LineNumberFormatSectionId), x);
                        return x;
                    }).ToList();
                    save = true;
                }

                //DELETE Line Number Formate section 
                var lineNumberFormateSectionIds = lineNumberFormateSectionExisting.Where(x => x.Update && !x.Active).Select(y => y.LineNumberFormatSectionId.Value);
                if (lineNumberFormateSectionIds.Any())
                {
                    DeleteLineNumberFormateSection(lineNumberFormateSectionIds);
                    save = true;
                }
            }

            //if (save)
            //    _APIDBContext.SaveChanges();
            return true;
        }

        public bool DeleteLineNumberFormateSection(IEnumerable<Guid> lineNumberSectionIds)
        {
            if (lineNumberSectionIds == null)
                return false;
            var lineNumberFormateSectionsDBs = GetNumberFormatSectionsFromDatabase(lineNumberSectionIds);
            if (lineNumberFormateSectionsDBs != null)
            {
                lineNumberFormateSectionsDBs.ToList().ForEach(y =>
                {
                    y.Active = false;
                });
            }
            return true;
        }

        #endregion

        #region LineNumberFormateSectionType

        public IEnumerable<LineNumberFormatSectionTypeDto> GetlineNumberFormatSectionType()
        {
            var lineNumberFormateSectionType = _APIDBContext.TblLineNumberFormatSectionTypes.ToList();

            return _mapper.Map<IEnumerable<LineNumberFormatSectionTypeDto>>(lineNumberFormateSectionType);
        }
        #endregion LineNumberFormateSectionType

        #region UserSecurityRole

        public IEnumerable<UserSecurityRoleDto> GetUserSecurityRoleTemplate()
        {
            var securityRoleDB = _APIDBContext.TestSecurityRoles.AsNoTracking().Where(x=> x.Active);
            securityRoleDB = securityRoleDB.Include(x => x.TestSecurityRolePermissions.Where(x => x.Active)).ThenInclude(y => y.TestSecurityPermission);

            var securityRoles = _mapper.Map<IEnumerable<TestSecurityRolePermissionsFlattenedDto>>(securityRoleDB.OrderBy(x => x.Name));
            //for testing
            var data = _mapper.Map<IEnumerable<UserSecurityRoleDto>>(securityRoleDB);

            var securityPermissions = SecurityPermission();

            if(securityRoles.Any())
            {
                var test = SecurityPermissions.Hierarchy(securityPermissions, securityRoles.SelectMany(x=> x.TestSecurityRolePermissionsFlattened));
                // _ = securityRoles.Select(x => { x.SecurityRolePermissions = test; return x; }).ToList(); 
                securityRoles = securityRoles.Select(x =>
                {
                    x.SecurityRolePermissions = test;
                    return x;
                }).ToList(); 
            }

            return _mapper.Map<IEnumerable<UserSecurityRoleDto>>(securityRoles);
        }

        public IEnumerable<TestUserSecurityPermissionDto> SecurityPermission(string path = null, string action = null)
        {
            var pathParam = new SqlParameter("@Path", SqlDbType.NVarChar, 255)
            {
                IsNullable = true,
                Value = !string.IsNullOrEmpty(path) ? path : DBNull.Value
            };
            var actionParam = new SqlParameter("@Action", SqlDbType.NVarChar, 255)
            {
                IsNullable = true,
                Value = !string.IsNullOrEmpty(action) ? action : DBNull.Value
            };
            var query = "EXEC [dbo].[GetUserSecurityPermission] @Path, @Action";

            var securityPermissions = _APIDBContext.spSecurityPermissions
                .FromSqlRaw(query, pathParam, actionParam)
                .ToList();

            return _mapper.Map<IEnumerable<TestUserSecurityPermissionDto>>(securityPermissions);
        }

        #endregion UserSecurityRole
    }
}
