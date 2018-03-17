using StudentHousing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.CompositeModel
{
    public class ListingEditModel
    {
        public ListingModel Listing { get; set; }
        public List<byte[]> Images { get; set; }
    }
}
