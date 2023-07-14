using System.Collections.Generic;
using System.Security.Policy;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class Response<T>
    {

      
        private string testString { get; set; }

        public Response(bool result)
        {
            success = result;
        }
       
        public Response(object data)
        {
            Data = data;
            error = null;
            success = true;
            message = string.Empty;
        }

        public object Data { get; set; }
        public string[] error { get; set; }
        public  bool success { get; set; } 
        public string message { get; set; }
       
    }
}
