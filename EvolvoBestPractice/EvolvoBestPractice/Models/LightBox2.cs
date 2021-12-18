using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class LightBox2
    {
        private static Item lightitem = Sitecore.Context.Database.GetItem(lightbox2Details);
        private static Item lightitemdesc = Sitecore.Context.Database.GetItem(lightbox2Values);

        public string Details1()
        {
            Sitecore.Data.Fields.Field detail = lightitemdesc.Fields["Detail1"];
            string Detail = detail.Value;
            Console.WriteLine(Detail);
            return Detail;
        }

        public String ButtonText()
        {
            Sitecore.Data.Fields.Field buttontext = lightitem.Fields["Button_Text"];
            string ButtonText = buttontext.Value;
            return ButtonText;
        }

        public string Details2()
        {
            Sitecore.Data.Fields.Field detail = lightitemdesc.Fields["Detail2"];
            string Detail = detail.Value;
            Console.WriteLine(Detail);
            return Detail;
        }

        public string Details3()
        {
            Sitecore.Data.Fields.Field detail = lightitemdesc.Fields["Detail3"];
            string Detail = detail.Value;
            Console.WriteLine(Detail);
            return Detail;
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