using Pagination_Project.API.Domain.Enum;
using System;

namespace Pagination_Project.API.Domain.Entities
{
    public class LineNumberFormatSectionTypeDto
    {
        public Guid LineNumberFormatSectionTypeId { get; set; }

        public LineNumberFormatSectionType Index { get; set; }

        public string Name { get; set; }
    }
}
