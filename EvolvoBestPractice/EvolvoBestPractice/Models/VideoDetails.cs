using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class VideoDetails
    {
        private static Item items = Sitecore.Context.Database.GetItem(videoLink);

        public String Image()
        {
            Sitecore.Data.Fields.ImageField image = items.Fields["Image"];
            string imageURL = string.Empty;
            if (image != null && image.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem img = new Sitecore.Data.Items.MediaItem(image.MediaItem);
                imageURL = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(img));
            }
            return imageURL;
        }

        public string VideoLink()
        {
            Sitecore.Data.Fields.LinkField linkField = items.Fields["Call_To_Action"];
            string url = "";
            url += linkField.Url;
            return url;
        }

        public string Title()
        {
            Sitecore.Data.Fields.Field title = items.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string Description()
        {
            Sitecore.Data.Fields.Field description = items.Fields["Description"];
            string Description = description.Value;
            Console.WriteLine(Description);
            return Description;
        }
    }
}