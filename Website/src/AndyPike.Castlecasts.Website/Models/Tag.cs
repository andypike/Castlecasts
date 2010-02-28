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

        [Property]
        public string Name { get; set; }

        [HasAndBelongsToMany]
        public IList<Episode> Episodes { get; set; }
    }
}