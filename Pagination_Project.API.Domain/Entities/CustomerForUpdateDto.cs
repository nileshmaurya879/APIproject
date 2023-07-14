using System.Net.Http.Headers;

namespace Pagination_Project.API.Domain.Entities
{
    public class CustomerForUpdateDto : CustomerForManupulationDto
    {
        private CustomerDto _current { get; set; }
        public CustomerDto Current { 
            get 
            {
                 return _current; 
            } 
            
            set
            { 
                _current = value;
            } 
        }

        public bool exist {
            get 
            {
                if(base.CustomerId != 0)
                {
                    return Current != null;
                }
                return false; 
            } 
        
        }
        public bool update { 
            get 
            {
                if (exist)
                {
                    var customerid1 = Current.CustomerId;
                    var customerid2 = base.CustomerId;
                    if ((customerid1 != customerid2) || (Current.CustomerName != base.CustomerName) || (Current.DateOfBirth != base.DateOfBirth) || (Current.email != Current.email))
                        return true;
                    return false;
                }
                return false; 
            } 
        }

        //public bool Update() { 
        
        //    return (_current.CustomerName != CustomerName || _current.email != Email || _current.DateOfBirth != DateOfBirth);
        //}

    }
}
