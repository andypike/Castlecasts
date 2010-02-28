using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord]
    public class Comment : ActiveRecordLinqBase<Comment>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string Name { get; set; }
        
        [Property]
        public string Email { get; set; }

        [Property]
        public string WebsiteUrl { get; set; }

        [Property(SqlType = "nvarchar(max)")]
        public string Text { get; set; }

        [BelongsTo]
        public Episode Episode { get; set; }
    }
}