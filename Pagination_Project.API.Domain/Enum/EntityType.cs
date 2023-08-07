using Pagination_Project.API.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Enum
{
    public enum EntityType
    {
        None = 0,

        Customer = 1,

        LineNumberFormate = 2,

        [DisplayString(ResourceKey = "Address")]
        Address = 3
    }

    public static class EntityHelper
    {
        private static T GetAttribute<T>(this EntityType value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }
        public static string ToName(this EntityType value)
        {
            var attribute = value.GetAttribute<DisplayStringAttribute>();
            return attribute == null ? value.ToString() : attribute.ResourceName ?? attribute.ResourceKey;
        }
    }
    
}
