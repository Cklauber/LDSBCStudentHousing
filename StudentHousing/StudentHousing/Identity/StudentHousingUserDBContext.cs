using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Identity
{
    public class StudentHousingUserDBContext : IdentityDbContext<StudentHousingUser>
    {
        public StudentHousingUserDBContext(DbContextOptions<StudentHousingUserDBContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentHousingUser>(user => user.HasIndex(x => x.FirstName).IsUnique(false));
            builder.Entity<StudentHousingUser>(user => user.HasIndex(x => x.LastName).IsUnique(false));
        }
    }
}
