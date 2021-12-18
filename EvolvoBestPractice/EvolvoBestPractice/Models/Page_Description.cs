using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class Page_Description
    {
        private static Item pageItems = Sitecore.Context.Database.GetItem(pageDetails);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = pageItems.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string ButtonText()
        {
            Sitecore.Data.Fields.Field button_text = pageItems.Fields["Button_Text"];
            string ButtonText = button_text.Value;
            return ButtonText;
        }

        public string Sub_Title()
        {
            Sitecore.Data.Fields.Field subTitle = pageItems.Fields["Sub_Title"];
            string SubTitle = subTitle.Value;
            Console.WriteLine(SubTitle);
            return SubTitle;
        }

        public string Description()
        {
            Sitecore.Data.Fields.Field description = pageItems.Fields["Description"];
            string Description = description.Value;
            Console.WriteLine(Description);
            return Description;
        }

        public string Image()
        {
            Sitecore.Data.Fields.ImageField image = pageItems.Fields["Image"];
            string imageURL = string.Empty;
            if (image != null && image.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem img = new Sitecore.Data.Items.MediaItem(image.MediaItem);
                imageURL = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(img));
            }
            return imageURL;
        }

        public string Discover()
        {
            Sitecore.Data.Fields.LinkField linkField = pageItems.Fields["Discover"];
            string url = "";
            url += linkField.Url;
            return url;
        }
    }
}