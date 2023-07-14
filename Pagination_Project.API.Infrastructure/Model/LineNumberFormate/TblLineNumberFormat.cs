using System.Collections.Generic;
using System;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class TblLineNumberFormat
    {
        public TblLineNumberFormat()
        {
          //  TblLineNumberFormatSection = new HashSet<TblLineNumberFormatSection>();
        }

        public Guid LineNumberFormatId { get; set; }
        public Guid? InstanceId { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public bool AllowFreeForm { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid EditedBy { get; set; }
        public DateTime EditedDate { get; set; }
        public bool Active { get; set; }

        public virtual TblInstance Instance { get; set; }
        public virtual ICollection<TblLineNumberFormatSection> TblLineNumberFormatSections { get; set; }
    }
}
