using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHousing.CompositeModel;
using StudentHousing.Models;
using StudentHousing.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Controllers
{
    public class ListingController : Controller
    {
        private IDataService _model;
        public ListingController(IDataService itemData)
        {
            _model = itemData;

        }
        public IActionResult Index()
        {
            var model = _model.GetAll();
            return View(model);
        }
        public IActionResult ViewItem(int id)
        {
            var Listing = _model.Get(id);
            return View(Listing);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListingEditModel _newListing, List<IFormFile> Images)
        {
            //if (ModelState.IsValid)
            if (true)
            {
                var newListing = new ListingModel();
                newListing = _newListing.Listing;
                newListing.Images = new List<Images>();
                foreach (var item in Images)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            newListing.Images.Add(new Images { Image = stream.ToArray() });
                        }
                    }
                }



                _model.Add(newListing);
                return RedirectToAction(nameof(ViewItem), new { id = newListing.Id });
            }


            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ListingModel Listing = _model.Get(id);
            ListingEditModel myModel = new ListingEditModel();
            myModel.Listing = Listing;
            foreach(Images img in Listing.Images)
            {
                myModel.Images.Add(img.Image);
            }
            return View(myModel);
        }
        //[HttpPost, ValidateAntiForgeryToken]
        //public IActionResult Edit(ListingEditModel _listing, List<IFormFile> Images)
        //{
        //    ListingModel Listing = _model.Get(_listing.Listing.Id);
        //    Listing = _listing.Listing;
        //}


    }
}
