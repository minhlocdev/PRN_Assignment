using System;
using System.Collections.Generic;

#nullable disable

namespace data.Models
{
    public partial class Test
    {
        public Test()
        {
            QuestionTests = new HashSet<QuestionTest>();
        }

        public string Id { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<QuestionTest> QuestionTests { get; set; }
    }
}
