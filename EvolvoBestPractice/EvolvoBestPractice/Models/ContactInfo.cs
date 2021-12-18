using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class ContactInfo
    {
        private static Item contactItem = Sitecore.Context.Database.GetItem(constContactInfo);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = contactItem.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }
        public string Location()
        {
            Sitecore.Data.Fields.Field location = contactItem.Fields["Location"];
            string Location = location.Value;
            Console.WriteLine(Location);
            return Location;
        }
        public int Telephone()
        {
            Sitecore.Data.Fields.Field telephone = contactItem.Fields["Telephone"];
            int Telephone = int.Parse(telephone.Value);
            Console.WriteLine(Telephone);
            return Telephone;
        }
        public string Email()
        {
            Sitecore.Data.Fields.Field email = contactItem.Fields["Email"];
            string Email = email.Value;
            Console.WriteLine(Email);
            return Email;
        }

        public string MainTitle()
        {
            Sitecore.Data.Fields.Field maintitle = contactItem.Fields["Main_Title"];
            string MainTitle = maintitle.Value;
            Console.WriteLine(MainTitle);
            return MainTitle;
        }
    }
}