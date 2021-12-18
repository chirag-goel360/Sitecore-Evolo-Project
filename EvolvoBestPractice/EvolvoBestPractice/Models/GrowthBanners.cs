using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class GrowthBanners
    {
        private static Item items = Sitecore.Context.Database.GetItem(growthBanner);

        public List<Banners> ChildMember()
        {
            List<Banners> members = new List<Banners>();
            Sitecore.Collections.ChildList children = items.Children;
            for (int childIndex = 0; childIndex < children.Count; childIndex++)
            {
                members.Add(new Banners
                {
                    Title = children[childIndex].Fields["Title"].ToString(),
                    Description = children[childIndex].Fields["Description"].ToString(),
                    Image = fetchImage(children[childIndex].Fields["Image"])
                });
            }
            return members;
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

    public class Banners
    {
        public string Title;
        public string Description;
        public string Image;
    }
}