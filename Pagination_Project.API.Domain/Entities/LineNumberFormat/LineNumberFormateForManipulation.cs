using System.Collections.Generic;
using System;

namespace Pagination_Project.API.Domain.Entities
{
    public abstract class LineNumberFormateForManipulation
    {
        public Guid? LineNumberFormatId { get; set; }

        public Guid InstanceId { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public bool AllowFreeForm { get; set; }

        public bool Active { get; set; } = true;

        public IEnumerable<LineNumberFormatSectionManipulationDto> Sections { get; set; }

    }
}
