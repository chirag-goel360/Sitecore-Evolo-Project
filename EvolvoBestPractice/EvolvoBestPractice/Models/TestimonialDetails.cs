using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class TestimonialDetails
    {
        private static Item testimonialItem = Sitecore.Context.Database.GetItem(testimonialDetails);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = testimonialItem.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string Image()
        {
            Sitecore.Data.Fields.ImageField image = testimonialItem.Fields["Image"];
            string imageURL = string.Empty;
            if (image != null && image.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem img = new Sitecore.Data.Items.MediaItem(image.MediaItem);
                imageURL = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(img));
            }
            return imageURL;
        }
    }
}