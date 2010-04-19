using System.Collections.Generic;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.MRandAR.Models
{
    [ActiveRecord]
    public class Project : ActiveRecordLinqBase<Project>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string Name { get; set; }

        [HasMany]
        public IList<Issue> Issues { get; set; }
    }
}