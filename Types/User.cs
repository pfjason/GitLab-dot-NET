using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using unirest_net.http;
using System.Web;

namespace GitLab
{
    public partial class GitLab
    {
        public class User
        {
            public string name
                , username
                , state
                , email
                , created_at
                , bio
                , skype
                , linkedin
                , twitter
                , website_url
                , extern_uid
                , provider
                , avatar_url
                , current_sign_in_at;
            public int id, color_scheme_id, theme_id;
            public bool two_factor_enabled, can_create_group, is_admin;

            public static List<User> List(Config _Config)
            {                
                List<User> RetVal = new List<User>();

                //TODO: Implement function here 
                throw new NotImplementedException();

                return RetVal;
            }
        }
    }
}
