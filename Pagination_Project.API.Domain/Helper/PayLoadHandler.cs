using Pagination_Project.API.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Pagination_Project.API.Domain.Helper
{
    public static class PayLoadHandler
    {

        public static void justify(object data, Guid? parentId)
        {
            if (data is IList<LineNumberFormatCreationDto> lineNumberFormate)
                LineNumberFormatePayload(lineNumberFormate, parentId);
            if(data is IList<LineNumberFormatForUpdateDto> lineNumberFormateUpdate)
                LineNumberFormatePayload(lineNumberFormateUpdate, parentId);

        }
        public static void LineNumberFormatePayload(IEnumerable<LineNumberFormateForManipulation> lineFormate, Guid? instanceId)
        {
            _ = lineFormate.Select(x =>
            {
                x.LineNumberFormatId = !x.LineNumberFormatId.HasValue ? Guid.NewGuid() : x.LineNumberFormatId;
                x.InstanceId = instanceId ?? Guid.Empty;
                x.Sections = x.Sections?.Select(y =>
                {
                    y.LineNumberFormatId = x.LineNumberFormatId;
                    y.LineNumberFormatSectionId = !y.LineNumberFormatSectionId.HasValue ? Guid.NewGuid() : y.LineNumberFormatSectionId;
                    return y;
                }).ToList();
                return x;
            }).ToList();
        }
    }
}
