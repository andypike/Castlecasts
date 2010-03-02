using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord]
    public class Link : ActiveRecordLinqBase<Link>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string Text { get; set; }

        [Property]
        public string Url { get; set; }

        [BelongsTo]
        public Episode Episode { get; set; }
    }
}
