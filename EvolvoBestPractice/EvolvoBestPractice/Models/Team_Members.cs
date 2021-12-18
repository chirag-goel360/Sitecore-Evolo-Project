using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using static EvolvoBestPractice.Models.Constants;

namespace EvolvoBestPractice.Models
{
    public class Team_Members
    {
        private static Item items = Sitecore.Context.Database.GetItem(constTeamMembers);

        public List<Member> ChildMember()
        {
            List<Member> members = new List<Member>();
            Sitecore.Collections.ChildList children = items.Children;
            for(int childIndex = 0; childIndex < children.Count; childIndex++)
            {
                members.Add(new Member {
                    Name = children[childIndex].Fields["Name"].ToString(),
                    Role = children[childIndex].Fields["Role"].ToString(),
                    FacebookLink = fetchURL(children[childIndex].Fields["FaceBook_Link"]),
                    LinkedInLink = fetchURL(children[childIndex].Fields["LinkedIn_Link"]),
                    Image = fetchImage(children[childIndex].Fields["Image"])
                });
            }
            return members;
        }

        public string fetchImage(Sitecore.Data.Fields.ImageField image)
        {
            string imageURL = string.Empty;
            if(image != null && image.MediaItem != null)
            {
                Sitecore.Data.Items.MediaItem img = new Sitecore.Data.Items.MediaItem(image.MediaItem);
                imageURL = Sitecore.StringUtil.EnsurePrefix('/', Sitecore.Resources.Media.MediaManager.GetMediaUrl(img));
            }
            return imageURL;
        }

        public string fetchURL(Sitecore.Data.Fields.LinkField linkField)
        {
            string url = "";
            url += linkField.Url;
            return url;
        }
    }

    public class Member
    {
        public string Name;
        public string Role;
        public string LinkedInLink;
        public string FacebookLink;
        public string Image;
    }
}