using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities.Validation
{
    public class ReturnBase
    {
        public bool? IsCustom { get; set; }

        public string Message { get; set; }

        public ReturnBase(string message) 
        { 
            this.Message = message;
        }
        public ReturnBase(string message, bool? isCustom):this(message) 
        { 
            this.IsCustom = isCustom;
        }
    }
}
