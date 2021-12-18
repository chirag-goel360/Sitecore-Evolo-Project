using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class CompanySlider
    {
        private static Item items = Sitecore.Context.Database.GetItem(companySlides);

        public List<string> Images()
        {
            List<string> companyLogo = new List<String>();
            Sitecore.Collections.ChildList children = items.Children;
            for (int childIndex = 0; childIndex < children.Count; childIndex++)
            {
                companyLogo.Add(fetchImage(children[childIndex].Fields["Image"]));
            }
            return companyLogo;
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
}