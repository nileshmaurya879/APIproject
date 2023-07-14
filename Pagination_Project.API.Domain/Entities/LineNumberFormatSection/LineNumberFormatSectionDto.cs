using System;

namespace Pagination_Project.API.Domain.Entities
{
    public class LineNumberFormatSectionDto
    {
        public Guid? LineNumberFormatSectionId { get; set; }

        public Guid LineNumberFormatId { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public LineNumberFormatSectionTypeDto Type { get; set; }

        public bool AllowAlpha { get; set; }

        public bool AllowNumeric { get; set; }

        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public string AdditionalChars { get; set; }
    }
}
