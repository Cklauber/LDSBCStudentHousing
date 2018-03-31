using Microsoft.EntityFrameworkCore;
using StudentHousing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Data
{
    public class ListingDbContext : DbContext
    {
        public ListingDbContext(DbContextOptions<ListingDbContext> options) : base(options)
        {

        }
        public DbSet<ListingModel> Items { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}
