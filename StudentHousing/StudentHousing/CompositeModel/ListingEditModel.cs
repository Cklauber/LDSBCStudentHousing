using StudentHousing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHousing.CompositeModel
{
    public class ListingEditModel
    {
        //public ListingModel Listing { get; set; }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Images> Images { get; set; }


        public List<byte[]> BitImages { get; set; }
        public List<String> GetImages()
        {
            List<String> Imgsources = new List<string>();
            string imgsrc = "";
            if (BitImages.Count > 0)
            {
                foreach (Images img in Images)
                {
                    imgsrc = Convert.ToBase64String(img.Image);
                    imgsrc = string.Format("data:image;base64,{0}", imgsrc);
                    Imgsources.Add(imgsrc);
                }
            }
            return Imgsources;
        }
    }
}
