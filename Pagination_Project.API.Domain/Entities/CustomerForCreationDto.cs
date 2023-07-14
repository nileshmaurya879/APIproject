﻿using System;

namespace Pagination_Project.API.Domain.Entities
{
    public class CustomerForCreationDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; }
    }
}
