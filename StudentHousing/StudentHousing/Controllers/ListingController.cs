﻿using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Create(ListingModel _newListing, List<IFormFile> Images)
        {
            if (ModelState.IsValid)
            {
                var newListing = _newListing;
                newListing.Images = await ToImageList(Images);
                _model.Add(newListing);
                return RedirectToAction(nameof(ViewItem), new { id = newListing.Id });
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _listing = _model.Get(id);
            return View(_listing);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ListingEditModel _listing, List<IFormFile> Images)
        {

            if (ModelState.IsValid)
            {
                ListingModel Listing = _model.Get(_listing.Id);
                Listing.Name = _listing.Name;
                Listing.Description = _listing.Description;

                //TODO: Edit pictures.
                //Probably the easiest way is going to be transforming the images, sending it
                //    to the _listing and then comparing with the picture in the Listing.
                //    According to the changes we can delete(OrderedParallelQuery make inactive),
                //    add and maybe update.


                //var updateListing = new ListingModel();
                //updateListing = _listing.Listing;
                //updateListing.Images = new List<Images>();
                //foreach (var item in Images)
                //{
                //    if (item.Length > 0)
                //    {
                //        using (var stream = new MemoryStream())
                //        {
                //            await item.CopyToAsync(stream);
                //            updateListing.Images.Add(new Images { Image = stream.ToArray() });
                //        }
                //    }
                //}
                _model.Update(Listing);
                return RedirectToAction(nameof(ViewItem), new { id = Listing.Id });
            }
            return View();

        }
        private async Task<List<Images>> ToImageList(List<IFormFile> Images)
        {
            var ImageList = new List<Images>();
            foreach (var item in Images)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        ImageList.Add(new Images { Image = stream.ToArray() });
                    }
                }
            }
            return ImageList;
        }
    }
}