using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentHousing.CompositeModel;
using StudentHousing.Identity;
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
        private readonly UserManager<StudentHousingUser> _userManager;
        private IDataService _model;
        public ListingController(IDataService itemData, 
            UserManager<StudentHousingUser> userManager)
        {
            _userManager = userManager;
            _model = itemData;

        }
        public IActionResult Index()
        {
            var model = _model.GetAll();
            return View(model);
        }
        public async Task<IActionResult> ManageItems()
        {
            var user = await _userManager.GetUserAsync(User);
            var model = _model.AllFromUser(user.Id);
            return View(model);
        }
        public IActionResult ViewItem(int id)
        {
            var Listing = _model.Get(id);
            return View(Listing);
        }
        [HttpGet, Authorize] 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> Create(ListingModel _newListing, List<IFormFile> Images)
        {
            if (ModelState.IsValid)
            {
                var newListing = _newListing;
                newListing.Images = await ToImageList(Images);
                var user = await _userManager.GetUserAsync(User);
                newListing.CreatedBy = user.Id;
                newListing.IsActive = true;
                _model.Add(newListing);
                return RedirectToAction(nameof(ViewItem), new { id = newListing.Id });
            }
            return View();
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var _listing = _model.Get(id);
            var user = await _userManager.GetUserAsync(User);
            if (_listing.CreatedBy == user.Id)
            {
                return View(_listing);
            }
            return RedirectToAction("Index", "Home");

        }
        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> Edit(ListingEditModel _listing, List<IFormFile> Images)
        {

            if (ModelState.IsValid)
            {
                ListingModel Listing = _model.Get(_listing.Id);
                var user = await _userManager.GetUserAsync(User);
                if (Listing.CreatedBy == user.Id)
                { 
                Listing.Name = _listing.Name;
                Listing.Description = _listing.Description;
                Listing.ContactName = _listing.ContactName;
                Listing.Email = _listing.Email;
                Listing.PhoneNumber = _listing.PhoneNumber;
                Listing.Rent = _listing.Rent;
                Listing.RentIncludeUtil = _listing.RentIncludeUtil;
                Listing.Utilities = _listing.Utilities;
                Listing.DownPayment = _listing.DownPayment;
                Listing.Address1 = _listing.Address1;
                Listing.Address2 = _listing.Address2;
                Listing.City = _listing.City;
                Listing.State = _listing.State;
                Listing.Zip = _listing.Zip;
                Listing.Bedroom = _listing.Bedroom;
                Listing.Bathroom = _listing.Bathroom;
                Listing.Kitchen = _listing.Kitchen;
                Listing.SqrFeet = _listing.SqrFeet;
                Listing.Amendities = _listing.Amendities;
                Listing.PetFriendly = _listing.PetFriendly;
                Listing.PeopleSignedUp = _listing.PeopleSignedUp;
                Listing.RoomAvailable = _listing.RoomAvailable;
                Listing.IsActive = _listing.IsActive;
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
                ModelState.AddModelError("", "Something is not right. Are you sure this item belongs to you?");
                return View();
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
