using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class LightBox1
    {
        private static Item lightitem = Sitecore.Context.Database.GetItem(lightbox1Details);
        private static Item lightitemdesc = Sitecore.Context.Database.GetItem(lightbox1Values);

        public string Details()
        {
            Sitecore.Data.Fields.Field description = lightitemdesc.Fields["Description"];
            string Description = description.Value;
            Console.WriteLine(Description);
            return Description;
        }

        public String ButtonText()
        {
            Sitecore.Data.Fields.Field buttontext = lightitem.Fields["Button_Text"];
            string ButtonText = buttontext.Value;
            return ButtonText;
        }

        public string Title()
        {
            Sitecore.Data.Fields.Field title = lightitem.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string Image()
        {
            Sitecore.Data.Fields.ImageField image = lightitem.Fields["Image"];
            string imageURL = string.Empty;
            if (image != null && image.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem img = new Sitecore.Data.Items.MediaItem(image.MediaItem);
                imageURL = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(img));
            }
            return imageURL;
        }

        public string LightBox()
        {
            Sitecore.Data.Fields.LinkField linkField = lightitem.Fields["LightBox"];
            string url = "";
            url += linkField.Url;
            return url;
        }
    }
}