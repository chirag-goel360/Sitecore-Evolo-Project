using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class Header
    {
        private static Item items = Sitecore.Context.Database.GetItem(header);
        private static Item aboutitems = Sitecore.Context.Database.GetItem(headerAbout);

        public List<HeaderFields> HeaderItems()
        {
            List<HeaderFields> headerMembers = new List<HeaderFields>();
            Sitecore.Collections.ChildList children = items.Children;
            for (int childIndex = 0; childIndex < children.Count; childIndex++)
            {
                headerMembers.Add(new HeaderFields
                {
                    Item = children[childIndex].Fields["Item"].ToString(),
                    LinkText = children[childIndex].Fields["LinkText"].ToString(),
                });
            }
            return headerMembers;
        }

        public List<HeaderAboutFields> HeaderAboutItems()
        {
            List<HeaderAboutFields> headerAboutMembers = new List<HeaderAboutFields>();
            Sitecore.Collections.ChildList children = aboutitems.Children;
            for (int childIndex = 0; childIndex < children.Count; childIndex++)
            {
                headerAboutMembers.Add(new HeaderAboutFields
                {
                    Item = children[childIndex].Fields["Item"].ToString(),
                    Link = fetchURL(children[childIndex].Fields["Link"]),
                });
            }
            return headerAboutMembers;
        }

        public string fetchURL(Sitecore.Data.Fields.LinkField linkField)
        {
            string url = "";
            url += linkField.Url;
            return url;
        }
    }

    public class HeaderFields
    {
        public string Item;
        public string LinkText;
    }

    public class HeaderAboutFields
    {
        public string Item;
        public string Link;
    }
}