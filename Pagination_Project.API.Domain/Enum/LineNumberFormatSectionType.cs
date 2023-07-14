
using Pagination_Project.API.Domain.Attributes;

namespace Pagination_Project.API.Domain.Enum
{
    public enum LineNumberFormatSectionType
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Pipe Size
        /// </summary>
        [DisplayString(ResourceKey = "Size", ResourceName = "Pipe Size")]
        Size = 1,

        /// <summary>
        /// Pipe Spec
        /// </summary>
        [DisplayString(ResourceKey = "Spec", ResourceName = "Pipe Spec")]
        Spec = 2,

        /// <summary>
        /// Trim Code
        /// </summary>
        [DisplayString(ResourceKey = "TrimCode", ResourceName = "Trim Code")]
        TrimCode = 3,

        /// <summary>
        /// Fluid
        /// </summary>
        [DisplayString(ResourceKey = "Fluid")]
        Fluid = 4,

        /// <summary>
        /// Insulation Class
        /// </summary>
        [DisplayString(ResourceKey = "InsulationClass", ResourceName = "Insulation Class")]
        InsulationClass = 5,

        /// <summary>
        /// Service Code
        /// </summary>
        [DisplayString(ResourceKey = "ServiceCode", ResourceName = "Service Code")]
        ServiceCode = 6,

        /// <summary>
        /// Pipe No
        /// </summary>
        [DisplayString(ResourceKey = "PipeNo", ResourceName = "Pipe No")]
        PipeNo = 7
    }
}
