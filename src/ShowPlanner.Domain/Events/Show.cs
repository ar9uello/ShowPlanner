using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShowPlanner.Shows
{
    public class Show : FullAuditedAggregateRoot<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsFree { get; set; }

        public DateTime StartTime { get; set; }

        public ICollection<ShowAttendee> Attendees { get; set; }

        public Show()
        {
            Attendees = new List<ShowAttendee>();
        }
    }
}
