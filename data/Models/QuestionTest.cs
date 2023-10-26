using System;
using System.Collections.Generic;

#nullable disable

namespace data.Models
{
    public partial class QuestionTest
    {
        public string QuestionId { get; set; }
        public string TestId { get; set; }
        public string UserId { get; set; }
        public int CorrectAnswer { get; set; }
        public int WrongAnswer { get; set; }

        public virtual Question Question { get; set; }
        public virtual Test Test { get; set; }
        public virtual User User { get; set; }
    }
}
