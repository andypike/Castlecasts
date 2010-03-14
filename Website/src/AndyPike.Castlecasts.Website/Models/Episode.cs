using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;
using Castle.Components.Pagination;
using Castle.MonoRail.Framework.Helpers;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord]
    public class Episode : ActiveRecordLinqBase<Episode>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property(NotNull = true, Length = 255)]
        public string Title { get; set; }

        [Property(NotNull = true, SqlType = "nvarchar(max)")]
        public string Description { get; set; }

        [Property(NotNull = true, SqlType = "nvarchar(max)")]
        public string MovieHTML { get; set; }

        [Property(NotNull = true, SqlType = "nvarchar(max)")]
        public string InfoHTML { get; set; }

        [Property(NotNull = true)]
        public DateTime CreatedAt { get; set; }

        [BelongsTo(NotNull = true)]
        public User CreatedBy { get; set; }

        [HasAndBelongsToMany(Table = "EpisodeTag", ColumnKey = "Episode_Id", ColumnRef = "Tag_Id", Cascade = ManyRelationCascadeEnum.SaveUpdate)]
        public IList<Tag> Tags { get; set; }

        [HasMany(Cascade = ManyRelationCascadeEnum.SaveUpdate, OrderBy = "CreatedAt ASC")]
        public IList<Comment> Comments { get; set; }

        public string SeoTitle
        {
            get
            {
                string seoTitle = Regex.Replace(Title.Trim(), @"\W", "-");      //Replace . with - hyphen
                seoTitle = Regex.Replace(seoTitle, @"\055+", "-").Trim('-');    //Replace multiple "-" hyphen with single "-" hyphen.

                return seoTitle.ToLower();
            }
        }

        public string RssPubDate
        {
            get
            {
                return CreatedAt.ToString("ddd, dd MMM yyyy 00:00:00 -0000");
            }
        }

        public static Episode[] FindAllLatestFirst()
        {
            return Queryable.OrderByDescending(e => e.CreatedAt).ToArray();
        }

        public static IPaginatedPage<Episode> GetLatestEpisodesPaged(int page, int pageSize)
        {
            return PaginatedFind(Queryable
                .OrderByDescending(e => e.CreatedAt), page, pageSize);
        }



        //TODO: Fork and send pull request
        public static IPaginatedPage<T> PaginatedFind<T>(IQueryable<T> query, int page, int pageSize)
        {
            page = (page == 0) ? 1 : page;

            int firstResult = ((page - 1) * pageSize);

            ICollection<T> matches = query
                .Skip(firstResult)
                .Take(pageSize)
                .ToList();

            int count = query.Count();

            return PaginationHelper.CreateCustomPage(matches, pageSize, page, count);
        }

        public void UpdateTags(string input, char separator)
        {
            Tags = new List<Tag>();

            string[] tagNames = input.Split(separator);
            foreach (var tagName in tagNames)
            {
                //Look up the tag first
                string name = tagName;
                Tag tag = Tag.Queryable.Where(t => t.Name == name).FirstOrDefault() ?? new Tag {Name = name};

                Tags.Add(tag);
            }
        }
    }
}