using StudentHousing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Services
{
    public interface IDataService
    {
        IEnumerable<ListingModel> GetAll();
        ListingModel Get(int id);
        ListingModel Add(ListingModel newListing);
        ListingModel Update(ListingModel listing);
        List<Images> GetImagesOnly(int id);
        ListingModel GetListingOnly(int id);
        IEnumerable<ListingModel> AllFromUser(string userId);

    }
}
