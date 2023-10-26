using System;
using System.Collections.Generic;

#nullable disable

namespace data.Models
{
    public partial class User
    {
        public User()
        {
            QuestionTests = new HashSet<QuestionTest>();
            Tasks = new HashSet<Task>();
            UserCourses = new HashSet<UserCourse>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<QuestionTest> QuestionTests { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
