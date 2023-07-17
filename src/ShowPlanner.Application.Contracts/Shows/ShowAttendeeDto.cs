using System;

namespace ShowPlanner.Shows
{
    public class ShowAttendeeDto
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
