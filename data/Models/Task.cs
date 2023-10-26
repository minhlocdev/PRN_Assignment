using System;
using System.Collections.Generic;

#nullable disable

namespace data.Models
{
    public partial class Task
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime CompleteDate { get; set; }

        public virtual User User { get; set; }
    }
}
