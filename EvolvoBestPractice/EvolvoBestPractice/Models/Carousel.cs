using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class Carousel
    {
        private static Item items = Sitecore.Context.Database.GetItem(carouselItems);

        public List<Slide> CarouselItems()
        {
            List<Slide> slides = new List<Slide>();
            MultilistField slidesField = items.Fields["Carousel"];
            if (slidesField?.Count > 0)
            {
                var slideItems = slidesField.GetItems();
                foreach (var slideItem in slideItems)
                {
                    var detailsField = slideItem.Fields["Details"];
                    var details = detailsField?.Value;
                    var authorField = slideItem.Fields["Author"];
                    var author = authorField?.Value;
                    var roleField = slideItem.Fields["Role"];
                    var role = roleField?.Value;
                    var imageField = fetchImage(slideItem.Fields["Image"]);
                    slides.Add(new Slide {
                        Details = details, 
                        Author = author, 
                        Image = imageField, 
                        Role = role 
                    });
                }
            }
            return slides;
        }

        public string fetchImage(Sitecore.Data.Fields.ImageField image)
        {
            string imageURL = string.Empty;
            if (image != null && image.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem img = new Sitecore.Data.Items.MediaItem(image.MediaItem);
                imageURL = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(img));
            }
            return imageURL;
        }
    }

    public class Slide
    {
        public string Details { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
    }
}