using System;
using System.ComponentModel.DataAnnotations;

namespace ShowPlanner.Shows
{
    public class ShowCreationDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000)]
        public string Description { get; set; }

        public bool IsFree { get; set; }

        public DateTime StartTime { get; set; }
    }
}
