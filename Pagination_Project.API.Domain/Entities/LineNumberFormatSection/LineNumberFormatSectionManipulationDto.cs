using System;

namespace Pagination_Project.API.Domain.Entities
{
    public class LineNumberFormatSectionManipulationDto
    {
        public Guid? LineNumberFormatSectionId { get; set; }

        public Guid? LineNumberFormatId { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }

        public Guid LineNumberFormatSectionTypeId { get; set; }

        public bool AllowAlpha { get; set; }

        public bool AllowNumeric { get; set; }

        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public string AdditionalChars { get; set; }

        public bool Active { get; set; } = true;
        public LineNumberFormatSectionDto Current { get; set; }

        public bool Exists { get { return LineNumberFormatSectionId.HasValue && Current != null; } }

        public bool Update
        {
            get
            {
                if (Exists)
                {
                    return (LineNumberFormatSectionId != Current.LineNumberFormatSectionId) ||
                            (Index != Current.Index) || (Name != Current.Name) ||
                            (LineNumberFormatSectionTypeId != Current.Type?.LineNumberFormatSectionTypeId) ||
                            (AllowAlpha != Current.AllowAlpha) || (AllowNumeric != Current.AllowNumeric) ||
                            (MinLength != Current.MinLength) || (MaxLength != Current.MaxLength) || (!Active);
                }
                return true;

            }
        }
    }
}
