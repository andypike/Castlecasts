using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.NVelocity.Models
{
    [ActiveRecord]
    public class Issue : ActiveRecordLinqBase<Issue>
    {
        public string Field
        {
            get{ return null;} 
        }

        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string Summary { get; set; }

        [Property(Length = 4001)]
        public string Description { get; set; }

        [Property]
        public IssueType Type { get; set; }

        [BelongsTo]
        public Project Project { get; set; }
    }
}