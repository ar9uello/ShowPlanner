using System;
using Volo.Abp.Auditing;

namespace ShowPlanner.Shows
{
    public class ShowAttendee : IHasCreationTime
    {
        public Guid UserId { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
