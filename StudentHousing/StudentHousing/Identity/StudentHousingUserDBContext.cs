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
    }
}
