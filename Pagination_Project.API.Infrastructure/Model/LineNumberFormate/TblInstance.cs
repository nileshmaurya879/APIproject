using System;
using System.Collections.Generic;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class TblInstance
    {
        public Guid InstanceId { get; set; }
        public Guid InstanceTypeId { get; set; }
        public Guid OrganisationId { get; set; }
        public Guid InstanceContextId { get; set; }
        public Guid ProfileContactId { get; set; }
        public Guid InstanceAssetTypeId { get; set; }
        public string Name { get; set; }
     //   public string ConnectionString { get; set; }
        public string Logo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Notes { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid EditedBy { get; set; }
        public DateTime EditedDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<TblLineNumberFormat> TblLineNumberFormats { get; set; }
    }
}
