namespace ConversationStarter.Controllers
{
    using System.Collections.Generic;

    using Facebook;

    using Newtonsoft.Json.Linq;

    public class Helper
    {
        public List<FbUser> GetFacebookFeed()
        {
            var fb = new FacebookClient();

            fb.AccessToken = "AccessToken"; // result.access_token;

            var friendListData = fb.Get("/me/friends");
            var friendListJson = JObject.Parse(friendListData.ToString());

            var fbUsers = new List<FbUser>();
            foreach (var friend in friendListJson["data"].Children())
            {
                var fbUser = new FbUser();
                fbUser.Id = friend["id"].ToString().Replace("\"", "");
                fbUser.Name = friend["name"].ToString().Replace("\"", "");
                fbUsers.Add(fbUser);
            }

            return fbUsers;
        }

        public class FbUser
        {
            public string Id { set; get; }

            public string Name { set; get; }
        }
    }
}