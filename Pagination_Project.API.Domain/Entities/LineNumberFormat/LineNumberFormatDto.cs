using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Pagination_Project.API.Domain.Entities
{
    public class LineNumberFormatDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? LineNumberFormatId { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public bool AllowFreeForm { get; set; }

        public IEnumerable<LineNumberFormatSectionDto> Sections { get; set; }
    }
}
