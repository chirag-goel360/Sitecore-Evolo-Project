using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class footer
    {
        private static Item footeritem = Sitecore.Context.Database.GetItem(constFooter);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = footeritem.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string Company()
        {
            Sitecore.Data.Fields.Field company = footeritem.Fields["Company"];
            string Company = company.Value;
            Console.WriteLine(Company);
            return Company;
        }

        public string Label()
        {
            Sitecore.Data.Fields.Field label = footeritem.Fields["Label"];
            string Label = label.Value;
            Console.WriteLine(Label);
            return Label;
        }

        public string LinkField()
        {
            Sitecore.Data.Fields.LinkField link = footeritem.Fields["Link"];
            string url = "";
            url += link.Url;
            return url;
        }
    }
}