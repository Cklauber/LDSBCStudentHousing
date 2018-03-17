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

        //[HttpPost]
        //public async Task<IActionResult> Create(ListingModel _newListing, List<IFormFile> Image)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    var newListing = new ListingModel();
        //    //    newListing.Name = _newListing.Name;
        //    //    newListing.Description = _newListing.Description;
        //    //    newListing.Image = _newListing.Image;
        //    //    _model.Add(newListing);
        //    //    return RedirectToAction(nameof(ViewItem), new { id = newListing.Id });
        //    //}
        //    if (ModelState.IsValid)
        //    {
        //        var newListing = new ListingModel();
        //        newListing.Name = _newListing.Name;
        //        newListing.Description = _newListing.Description;
        //        newListing.Image = _newListing.Image;
        //        foreach (var item in Image)
        //        {
        //            if (item.Length > 0)
        //            {
        //                using (var stream = new MemoryStream())
        //                {
        //                    await item.CopyToAsync(stream);
        //                    newListing.Image = stream.ToArray();
        //                }
        //            }
        //        }



        //        _model.Add(newListing);
        //        return RedirectToAction(nameof(ViewItem), new { id = newListing.Id });
        //    }


        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Create(ListingEditModel _newListing, List<IFormFile> Images)
        {
            //if (ModelState.IsValid)
            //{
            //    var newListing = new ListingModel();
            //    newListing.Name = _newListing.Name;
            //    newListing.Description = _newListing.Description;
            //    newListing.Image = _newListing.Image;
            //    _model.Add(newListing);
            //    return RedirectToAction(nameof(ViewItem), new { id = newListing.Id });
            //}
            if (ModelState.IsValid)
            {
                var newListing = new ListingModel();
                newListing.Name = _newListing.Listing.Name;
                newListing.Description = _newListing.Listing.Description;
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

    }
}
