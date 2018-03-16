using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentHousing.Data;
using StudentHousing.Models;

namespace StudentHousing.Services
{
    public class ListingDataService : IDataService
    {
        private ListingDbContext _context;
        public ListingDataService(ListingDbContext Context)
        {
            _context = Context;
        }
        public ListingModel Add(ListingModel newItem)
        {
            _context.Add(newItem);
            _context.SaveChanges();
            return newItem;
        }

        public ListingModel Get(int id)
        {
            ListingModel myItem = _context.Items.FirstOrDefault(x => x.Id == id);
            return myItem;
        }

        public IEnumerable<ListingModel> GetAll()
        {
            return _context.Items.OrderBy(x => x.Name);
        }
    }
}
