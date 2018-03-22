﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.Models
{
    public class ListingModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        ////Contact Information
        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string PhoneNumber { get; set; }
        ////House Financial Information
        public decimal Rent { get; set; }
        public decimal Utilities { get; set; }
        public bool RentIncludeUtil { get; set; }
        public decimal DownPayment { get; set; }
        ////TODO ENUM for contractPeriod
        //House General and Location
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        ////House Floorplan
        public int Bedroom { get; set; }
        public decimal Bathroom { get; set; }
        public int Kitchen { get; set; }
        public string Amendities { get; set; }
        public bool PetFriendly { get; set; }
        public int ParkingLots { get; set; }
        public int PeopleNeeded { get; set; }
        public int RoomsAvailable { get; set; }
        public bool ManRoom { get; set; }
        public List<Images> Images { get; set; }

        //TODO: public decimal SqrFeet { get; set; }






        //////Extra Information
        ////public bool PetFriendly { get; set; }
        ////public string Utilities { get; set; }
        ////public string Amendities { get; set; }
        ////public int PeopleSignedUp { get; set; }
        ////public int RoomAvailable { get; set; }
        ////public string MyProperty { get; set; }
        public List<String> GetImagesToSrc()
        {
            List<String> Imgsources = new List<string>();
            string imgsrc = "";
            if (Images.Count > 0)
            {
                foreach (Images img in this.Images)
                {
                    imgsrc = Convert.ToBase64String(img.Image);
                    imgsrc = string.Format("data:image;base64,{0}", imgsrc);
                    Imgsources.Add(imgsrc);
                }
            }
            return Imgsources;
        }
    }

    public class Images
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
    }
}
