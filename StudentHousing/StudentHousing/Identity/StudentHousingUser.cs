using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Identity
{
    public class StudentHousingUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static implicit operator string(StudentHousingUser v)
        {
            throw new NotImplementedException();
        }
    }
}
