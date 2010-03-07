using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using AndyPike.Castlecasts.Website.Extensions;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Linq;

namespace AndyPike.Castlecasts.Website.Models
{
    [ActiveRecord("`User`")]
    public class User : ActiveRecordLinqBase<User>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property(NotNull = true, Length = 50)]
        public string FirstName { get; set; }

        [Property(NotNull = true, Length = 50)]
        public string LastName { get; set; }

        [Property(NotNull = true, Unique = true, Length = 100)]
        public string Email { get; set; }

        [Property(NotNull = true, Length = 50)]
        public string PasswordSalt { get; set; }

        [Property(NotNull = true, Length = 50)]
        public string PasswordHash { get; set; }

        [Property]
        public Guid? Token { get; set; }

        [HasMany]
        public IList<Episode> Episodes { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public static Guid Authenticate(string email, string password)
        {
            User user = Queryable.Where(u => u.Email == email).FirstOrDefault();
            if(user == null) throw new SecurityException();

            string passwordHash = (password + user.PasswordSalt).ToMD5();
            if (user.PasswordHash != passwordHash) throw new SecurityException();

            user.Token = Guid.NewGuid();
            user.Save();

            return user.Token.Value;
        }
    }
}