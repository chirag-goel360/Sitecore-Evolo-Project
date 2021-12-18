using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class Pricing
    {
        private static Item items = Sitecore.Context.Database.GetItem(pricingDetails);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = items.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string Description()
        {
            string description = String.Empty;
            description = items.Fields["Description"].Value;
            Console.WriteLine(description);
            return description;
        }

        public List<PricingInfo> fetchPricing()
        {
            List<PricingInfo> pricings = new List<PricingInfo>();
            Sitecore.Collections.ChildList children = items.Children;
            for (int childIndex = 0; childIndex < children.Count; childIndex++)
            {
                pricings.Add(new PricingInfo
                {
                    Title = children[childIndex].Fields["Title"].ToString(),
                    Sub_Title = children[childIndex].Fields["Sub_Title"].ToString(),
                    Price = int.Parse(children[childIndex].Fields["Price"].ToString()),
                    Improve_Your_Email_Marketing = checkboxCheck(children[childIndex].Fields["Improve Your Email Marketing"]),
                    User_And_Admin_Rights_Control = checkboxCheck(children[childIndex].Fields["User And Admin Rights Control"]),
                    List_Building_And_Cleaning = checkboxCheck(children[childIndex].Fields["List Building And Cleaning"]),
                    Collected_Data_Management = checkboxCheck(children[childIndex].Fields["Collected Data Management"]),
                    More_Planning_And_Evaluation = checkboxCheck(children[childIndex].Fields["More Planning And Evaluation"]),
                    Request = fetchURL(children[childIndex].Fields["Request"]),
                    Button_Text = children[childIndex].Fields["Button_Text"].ToString()
                });
            }
            return pricings;
        }

        public string fetchURL(Sitecore.Data.Fields.LinkField linkField)
        {
            string url = "";
            url += linkField.Url;
            return url;
        }

        public bool checkboxCheck(Sitecore.Data.Fields.CheckboxField checkboxField)
        {
            if (checkboxField != null && checkboxField.Checked)
            {
                return true;
            }
            return false;
        }
    }

    public class PricingInfo
    {
        public string Title;
        public string Sub_Title;
        public int Price;
        public bool Improve_Your_Email_Marketing;
        public bool User_And_Admin_Rights_Control;
        public bool List_Building_And_Cleaning;
        public bool Collected_Data_Management;
        public bool More_Planning_And_Evaluation;
        public string Request;
        public string Button_Text;
    }
}