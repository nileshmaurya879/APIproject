using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities
{
    public class LineNumberFormatForUpdateDto : LineNumberFormateForManipulation
    {
        public LineNumberFormatDto Current { get; set; }

        public bool Exists { get { return LineNumberFormatId.HasValue && Current != null; } }

        public bool Update
        {
            get
            {
                if (Exists)
                {
                    return (LineNumberFormatId != Current.LineNumberFormatId) ||
                           ( Name != Current.Name) ||
                            (IsDefault != Current.IsDefault) ||
                            (AllowFreeForm != Current.AllowFreeForm) ||
                            (!Active);

                }
                return true;
            }
        }
    }
}
