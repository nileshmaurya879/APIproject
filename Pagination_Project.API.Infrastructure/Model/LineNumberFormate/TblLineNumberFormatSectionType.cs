using System.Collections.Generic;
using System;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class TblLineNumberFormatSectionType
    {
        public TblLineNumberFormatSectionType()
        {
            TblLineNumberFormatSections = new HashSet<TblLineNumberFormatSection>();
        }

        public Guid LineNumberFormatSectionTypeId { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid EditedBy { get; set; }
        public DateTime EditedDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<TblLineNumberFormatSection> TblLineNumberFormatSections { get; set; }
    }
}
