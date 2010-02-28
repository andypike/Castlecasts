using System;
using System.Collections.Generic;
using System.Linq;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord]
    public class Episode : ActiveRecordLinqBase<Episode>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string Title { get; set; }

        [Property(SqlType = "nvarchar(max)")]
        public string Description { get; set; }

        [Property]
        public int VimeoId { get; set; }

        [Property]
        public DateTime CreatedAt { get; set; }

        [BelongsTo]
        public User CreatedBy { get; set; }

        [HasMany]
        public IList<Tag> Tags { get; set; }

        [HasMany]
        public IList<Comment> Comments { get; set; }

        public static IList<Episode> GetLatestEpisodesPaged()
        {
            return Queryable.OrderBy(e => e.CreatedAt).ToList();
        }
    }
}