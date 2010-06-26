using System;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord]
    public class Submission : ActiveRecordLinqBase<Submission>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property(NotNull = true, Length = 255)]
        public string Name { get; set; }

        [Property(NotNull = true, Length = 255)]
        public string Email { get; set; }

        [Property(NotNull = true, Length = 255)]
        public string Title { get; set; }

        [Property(NotNull = true, SqlType = "nvarchar(max)")]
        public string Description { get; set; }

        [Property(NotNull = true, SqlType = "nvarchar(max)")]
        public string MovieHTML { get; set; }

        [Property(NotNull = true, SqlType = "nvarchar(max)")]
        public string ExtraInfo { get; set; }

        [Property]
        public DateTime CreatedAt { get; set; }

        [Property]
        public SubmissionStatus Status { get; set; }
    }
}