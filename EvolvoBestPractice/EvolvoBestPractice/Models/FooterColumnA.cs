using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EvolvoBestPractice.Models.Constants;
using Sitecore.Data.Items;

namespace EvolvoBestPractice.Models
{
    public class FooterColumnA
    {
        private static Item items = Sitecore.Context.Database.GetItem(footerColunmn1);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = items.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string About()
        {
            Sitecore.Data.Fields.Field about = items.Fields["About"];
            string About = about.Value;
            Console.WriteLine(About);
            return About;
        }
    }
}