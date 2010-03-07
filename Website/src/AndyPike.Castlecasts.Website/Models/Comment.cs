using System;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord]
    public class Comment : ActiveRecordLinqBase<Comment>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property(NotNull = true, Length = 50)]
        public string Name { get; set; }

        [Property]
        public string Email { get; set; }

        [Property]
        public DateTime CreatedAt { get; set; }

        [Property(NotNull = true, SqlType = "nvarchar(max)")]
        public string Text { get; set; }

        [BelongsTo(NotNull = true, Cascade = CascadeEnum.SaveUpdate)]
        public Episode Episode { get; set; }
    }
}