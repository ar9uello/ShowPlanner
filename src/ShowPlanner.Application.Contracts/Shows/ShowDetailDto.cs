using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace ShowPlanner.Shows
{
    public class ShowDetailDto : CreationAuditedEntityDto<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsFree { get; set; }

        public DateTime StartTime { get; set; }

        public List<ShowAttendeeDto> Attendees { get; set; }
    }
}
