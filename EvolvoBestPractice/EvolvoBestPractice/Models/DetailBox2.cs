using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class DetailBox2
    {
        private static Item items = Sitecore.Context.Database.GetItem(detailbox2);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = items.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string SubTitle()
        {
            Sitecore.Data.Fields.Field subtitle = items.Fields["Subtitle"];
            string Subtitle = subtitle.Value;
            return Subtitle;
        }

        public bool checkboxCheck(Sitecore.Data.Fields.CheckboxField checkboxField)
        {
            if (checkboxField != null && checkboxField.Checked)
            {
                return true;
            }
            return false;
        }

        public string Description()
        {
            string description = String.Empty;
            description = items.Fields["Description"].Value;
            Console.WriteLine(description);
            return description;
        }

        public bool List_building_framework()
        {
            return checkboxCheck(items.Fields["List building framework"]);
        }

        public bool Easy_database_browsing()
        {
            return checkboxCheck(items.Fields["Easy database browsing"]);
        }

        public bool User_administration()
        {
            return checkboxCheck(items.Fields["User administration"]);
        }

        public bool Automate_user_signup()
        {
            return checkboxCheck(items.Fields["Automate user signup"]);
        }

        public bool Quick_formatting_tools()
        {
            return checkboxCheck(items.Fields["Quick formatting tools"]);
        }

        public bool Fast_email_checking()
        {
            return checkboxCheck(items.Fields["Fast email checking"]);
        }

        public string ButtonR()
        {
            Sitecore.Data.Fields.Field button = items.Fields["ButtonR"];
            string Button = button.Value;
            Console.WriteLine(Button);
            return Button;
        }

        public string ButtonB()
        {
            Sitecore.Data.Fields.Field button = items.Fields["ButtonB"];
            string Button = button.Value;
            return Button;
        }
    }
}