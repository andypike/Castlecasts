using System.Collections.Generic;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord]
    public class Tag : ActiveRecordLinqBase<Tag>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property(NotNull = true, Length = 50, Unique = true)]
        public string Name { get; set; }

        [HasAndBelongsToMany(Table = "EpisodeTag", ColumnKey = "Tag_Id", ColumnRef = "Episode_Id", Inverse = true)]
        public IList<Episode> Episodes { get; set; }
    }
}