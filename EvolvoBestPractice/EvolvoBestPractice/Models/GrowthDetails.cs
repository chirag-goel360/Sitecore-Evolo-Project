using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class GrowthDetails
    {
        private static Item growthdescription = Sitecore.Context.Database.GetItem(growthDetails);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = growthdescription.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string Description()
        {
            Sitecore.Data.Fields.Field description = growthdescription.Fields["Description"];
            string Description = description.Value;
            Console.WriteLine(Description);
            return Description;
        }
    }
}