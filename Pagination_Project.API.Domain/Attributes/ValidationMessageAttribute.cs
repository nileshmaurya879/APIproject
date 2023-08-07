
using System;

namespace Pagination_Project.API.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ValidationMessageAttribute :Attribute
    {
        private int _code;
        private string _message;

      
        public ValidationMessageAttribute()
        {
        }

        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
