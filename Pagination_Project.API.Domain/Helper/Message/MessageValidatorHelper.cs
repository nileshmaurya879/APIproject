using Newtonsoft.Json.Linq;
using Pagination_Project.API.Domain.Attributes;
using Pagination_Project.API.Domain.Entities;
using Pagination_Project.API.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Helper.Message
{
    public enum MessgageValidationType
    {
        [DisplayString(ResourceKey = "None")]
        None = 0,

        [DisplayString(ResourceKey = "Already Exists")]
        [ValidationMessageAttribute(Code = 500, Message = "{0}already exists")]
        AlreadyExists = 1,

        [DisplayString(ResourceKey = "Invalid Value")]
        [ValidationMessageAttribute(Code = 500, Message = "Invalid {0}value")]
        InvalidValue = 2,
    }
    public static class MessageValidatorHelper
    {
          private static T GetAttribute<T>(this MessgageValidationType value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0
              ? (T)attributes[0]
              : null;
        }

        private static ValidationMessageAttribute ToValidationAttribute(this MessgageValidationType value)
            => value.GetAttribute<ValidationMessageAttribute>();
        public static ValidationReturn ToInputValidationResult(MessgageValidationType messageType, EntityType entityType)
           => ToInputValidationResult(messageType, entityType.ToName());

        public static int ToValidationCode(this MessgageValidationType value)
        {
            var attribute = value.ToValidationAttribute();
            return attribute != null ? attribute.Code : 0;
        }

        private static string StandardFailMessage(MessgageValidationType messageType, string typeName, string value)
        {
            var message = messageType.ToValidationMessage();
            typeName = message.Substring(0, 1) != "{" ? typeName.ToLowerInvariant() : typeName;
            return ComposeMessage(message, typeName, value?.ToLowerInvariant());
        }

        public static string ToValidationMessage(this MessgageValidationType value)
        {
            var attribute = value.ToValidationAttribute();
            return attribute?.Message;
        }

        private static string ComposeMessage(string message, string param1 = null, string param2 = null, string param3 = null, string param4 = null, string param5 = null)
           => string.Format(CultureInfo.InvariantCulture, message, !string.IsNullOrEmpty(param1) ? param1 + " " : string.Empty,
                                                                   !string.IsNullOrEmpty(param2) ? param2 + " " : string.Empty,
                                                                   !string.IsNullOrEmpty(param3) ? param3 + " " : string.Empty,
                                                                   !string.IsNullOrEmpty(param4) ? param4 + " " : string.Empty,
                                                                   !string.IsNullOrEmpty(param5) ? param5 + " " : string.Empty).Trim() + ".";

        public static ValidationReturn ToInputValidationResult(MessgageValidationType messageType, string typeName, string value = null)
        {
            var code = messageType.ToValidationCode();

            return messageType switch
            {
                MessgageValidationType.AlreadyExists or
                MessgageValidationType.InvalidValue => new ValidationReturn(code, StandardFailMessage(messageType, typeName, value), true)
            };
        }
    }
}
