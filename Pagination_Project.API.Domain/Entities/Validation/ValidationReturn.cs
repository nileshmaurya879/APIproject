using Pagination_Project.API.Domain.Entities.Validation;

namespace Pagination_Project.API.Domain.Entities
{
    public class ValidationReturn : ReturnBase
    {
        public int? Code { get; set; }

        public ValidationReturn() : this(null, null)
        {
        }

        public ValidationReturn(int code) : this(code, null)
        {
        }

        public ValidationReturn(int? code, string message) : this(code, message, null)
        {
        }

        public ValidationReturn(int? code, string message, bool? isCustom) : base(message, isCustom)
        {
            Code = code;
        }
    }
}
