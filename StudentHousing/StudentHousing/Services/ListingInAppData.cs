using StudentHousing.Models;
using StudentHousing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Services
{
    public class ListingInAppData : IDataService
    {
        List<ListingModel> _listings;

        public ListingInAppData()
        {
            if(_listings == null)
            {
                _listings = new List<ListingModel>()
                {
                    new ListingModel{Id = 0, Name = "Favela", Description = "A beautiful Favela for you!!!"},
                    new ListingModel{Id = 1, Name = "Bridges", Description = "Come live at the bridges so you're nearby the school!!!"},
                    new ListingModel{Id = 2, Name = "Sao Francisco", Description = "It is a beautiful and inexpansive place :D"}
                };
            }
        }

        public ListingModel Add(ListingModel newItem)
        {
            _listings.Add(newItem);
            return newItem;
        }

        public ListingModel Get(int id)
        {
            return _listings.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<ListingModel> GetAll()
        {
            return _listings.OrderBy(r => r.Name);
        }


    }
}
