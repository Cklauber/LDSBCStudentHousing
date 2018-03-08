using Microsoft.AspNetCore.Mvc;
using StudentHousing.Models;
using StudentHousing.Services;
using System;
using System.Collections.Generic;
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

        [HttpPost]
        public IActionResult Create(ListingModel _newListing)
        {
            if (ModelState.IsValid)
            {
                var newListing = new ListingModel();
                newListing.Name = _newListing.Name;
                newListing.Description = _newListing.Description;
                newListing.Id = _model.GetAll().Max(x => x.Id) + 1;
                _model.Add(newListing);
                return RedirectToAction(nameof(ViewItem), new { id = newListing.Id });
            }


            return View();
        }

    }
}
