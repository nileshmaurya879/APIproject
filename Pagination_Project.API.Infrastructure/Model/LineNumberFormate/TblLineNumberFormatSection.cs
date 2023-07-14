using System;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class TblLineNumberFormatSection
    {
        public Guid LineNumberFormatSectionId { get; set; }
        public Guid LineNumberFormatId { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Guid? LineNumberFormatSectionTypeId { get; set; }
        public bool AllowAlpha { get; set; }
        public bool AllowNumeric { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public string AdditionalChars { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid EditedBy { get; set; }
        public DateTime EditedDate { get; set; }
        public bool Active { get; set; }

        public virtual TblLineNumberFormat LineNumberFormat { get; set; }
        public virtual TblLineNumberFormatSectionType LineNumberFormatSectionType { get; set; }
    }
}
