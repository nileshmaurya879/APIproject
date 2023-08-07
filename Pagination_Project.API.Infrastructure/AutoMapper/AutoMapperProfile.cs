using AutoMapper;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Infrastructure.Model;
using System.Collections.Generic;
using System.Data;

namespace Pagination_Project.API.Infrastructure.AutoMapper
{
    public class SingleObjectToListConverter<T> : ITypeConverter<T, List<T>>
    {
        public List<T> Convert(T source, List<T> destination, ResolutionContext context)
        {
            return new List<T>() { source };
        }
    }
    public class AutoMapperProfile : Profile
    {
     
        public AutoMapperProfile()
        {
            #region Address

            CreateMap<TestAddress, AddressDto>().ReverseMap();

            CreateMap<AddressCreationDto, TestAddress>().ReverseMap();

            CreateMap<AddressCreationDto, AddressDto>().ReverseMap();

            #endregion

            #region Customer

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Customer, CustomerForUpdateDto>().ReverseMap();

            CreateMap<CustomerForCreationDto, Customer>().ReverseMap();
            CreateMap<CustomerForUpdateDto, CustomerDto>().ReverseMap();
            CreateMap<CustomerForUpdateDto, CustomerForCreationDto>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<spCustomer, CustomerDto>();

            #endregion

            #region Line Number Format

            CreateMap<LineNumberFormatDto, TblLineNumberFormat>().ReverseMap()
               //.ForMember(dest => dest.LineNumberFormatId, opt => opt.Ignore())
               .ForMember(
                   dest => dest.Sections,
                   opt => opt.MapFrom(src => src.TblLineNumberFormatSections));
              
            // .ForMember(dest => dest.LineNumberFormatId, opt => opt.Ignore());

            CreateMap<TblLineNumberFormat, LineNumberFormatCreationDto>().ReverseMap();
            CreateMap<TblLineNumberFormat, LineNumberFormateForManipulation>().ReverseMap();
            CreateMap<LineNumberFormatForUpdateDto, LineNumberFormatCreationDto>();

            #endregion Line Number Format

            #region LineNumber Formate section

            CreateMap<TblLineNumberFormatSectionType, LineNumberFormatSectionTypeDto>().ReverseMap();

            CreateMap<TblLineNumberFormatSection, LineNumberFormatSectionManipulationDto>().ReverseMap();

            CreateMap<LineNumberFormatSectionDto, LineNumberFormatSectionManipulationDto>().ReverseMap();

            CreateMap<TblLineNumberFormatSection, LineNumberFormatSectionDto>().ReverseMap();
            CreateMap<LineNumberFormatSectionDto, TblLineNumberFormatSection>().ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.LineNumberFormatSectionType));

            #endregion

            #region LineNumber Formate section

            CreateMap<TblLineNumberFormatSectionType,LineNumberFormatSectionTypeDto>().ReverseMap();

            #endregion

            #region SecurityRole

            CreateMap<TestSecurityRole, UserSecurityRoleDto>().ReverseMap();
            CreateMap<TestSecurityRolePermission, TestSecurityRolePermissionDto>();
            CreateMap<TestSecurityPermissionColumnForHierarchyDto, TestSecurityRolePermissionDto>();
            CreateMap<TestSecurityRole, TestSecurityRolePermissionsFlattenedDto>()
               .ForMember(
                   dest => dest.TestOrganisationID,
                   opt => opt.Ignore())
               .ForMember(
                   dest => dest.IsDerivedFromTemplate,
                   opt => opt.MapFrom(src => src.IsTemplate || src.IsDerivedFromTemplate))
               .ForPath(
                   dest => dest.TestSecurityRolePermissionsFlattened,
                   opt => opt.MapFrom(src => src.TestSecurityRolePermissions));
            CreateMap<TestSecurityRolePermissionsFlattenedDto, UserSecurityRoleDto>();
            CreateMap<SpSecurityPermission, TestUserSecurityPermissionDto>()
                .ForPath(
                    dest => dest.SecurityPermissionRow.testUserSecurityPermissionRowID,
                    opt => opt.MapFrom(src => src.testUserSecurityPermissionRowID))
                .ForPath(
                    dest => dest.testUserSecurityPermissionID,
                    opt => opt.MapFrom(src => src.testUserSecurityPermissionID))
                .ForPath(
                    dest => dest.SecurityPermissionColumn.UserSecurityPermissionColumnID,
                    opt => opt.MapFrom(src => src.UserSecurityPermissionColumnID))
                .ForPath(
                    dest => dest.SecurityPermissionRow.Path,
                    opt => opt.MapFrom(src => src.Path))
                .ForPath(
                    dest => dest.SecurityPermissionRow.Name,
                    opt => opt.MapFrom(src => src.SecurityPermissionRow))
                .ForPath(
                    dest => dest.SecurityPermissionColumn.Name,
                    opt => opt.MapFrom(src => src.SecurityPermissionColumn))
                .ForPath(
                    dest => dest.SecurityPermissionRow.Parent,
                    opt => opt.MapFrom(src => src.Parent));

            #endregion SecurityRole

        }
    }
}
