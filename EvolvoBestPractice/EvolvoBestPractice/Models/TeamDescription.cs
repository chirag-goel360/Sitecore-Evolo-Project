using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class TeamDescription
    {
        private static Item teamdescription = Sitecore.Context.Database.GetItem(constTeamDescription);

        public string Title()
        {
            Sitecore.Data.Fields.Field title = teamdescription.Fields["Title"];
            string Title = title.Value;
            Console.WriteLine(Title);
            return Title;
        }

        public string MainTitle()
        {
            Sitecore.Data.Fields.Field maintitle = teamdescription.Fields["Main_Title"];
            string MainTitle = maintitle.Value;
            return MainTitle;
        }
    }
}