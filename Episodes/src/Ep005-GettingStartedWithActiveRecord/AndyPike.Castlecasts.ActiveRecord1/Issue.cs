using System;
using System.Collections.Generic;
using System.Linq;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.ActiveRecord1
{
    [ActiveRecord]
    public class Issue : ActiveRecordLinqBase<Issue>
    {
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

        public static IList<Issue> FindAllBugs()
        {
            return Queryable.Where(i => i.Type == IssueType.Bug).ToList();
        }
    }

    public enum IssueType
    {
        Bug,
        NewFeature,
        Task
    }
}