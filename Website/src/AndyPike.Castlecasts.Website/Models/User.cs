using System.Collections.Generic;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord("`User`")]
    public class User : ActiveRecordLinqBase<User>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string FirstName { get; set; }

        [Property]
        public string LastName { get; set; }

        [Property]
        public string Email { get; set; }

        [Property]
        public string TwitterName { get; set; }

        [Property]
        public string PasswordSalt { get; set; }

        [Property]
        public string PasswordHash { get; set; }

        [HasMany]
        public IList<Episode> Episodes { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}