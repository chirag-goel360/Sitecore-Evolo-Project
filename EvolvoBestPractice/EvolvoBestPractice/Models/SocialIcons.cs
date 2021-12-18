using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EvolvoBestPractice.Models.Constants;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace EvolvoBestPractice.Models
{
    public class SocialIcons
    {
        private static Item items = Sitecore.Context.Database.GetItem(socialIcon);

        public List<Icons> ChildMember()
        {
            List<Icons> icons = new List<Icons>();
            Sitecore.Collections.ChildList children = items.Children;
            for (int childIndex = 0; childIndex < children.Count; childIndex++)
            {
                icons.Add(new Icons
                {
                    Icon = children[childIndex].Fields["Icon"].ToString(),
                    Link = fetchURL(children[childIndex].Fields["Link"])
                });
            }
            return icons;
        }

        public string fetchURL(Sitecore.Data.Fields.LinkField linkField)
        {
            string url = "";
            url += linkField.Url;
            return url;
        }
    }

    public class Icons
    {
        public string Icon { get; set; }
        public string Link { get; set; }
    }
}