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
        /// <summary>
        ///  GitLab User Object
        /// </summary>
        /// <remarks>
        /// See https://gitlab.com/help/api/users.md for API Reference
        /// </remarks>
        public partial class User
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
            public int id = -1, color_scheme_id = -1, theme_id = -1, projects_limit = -1;
            public bool two_factor_enabled = false, can_create_group = false, is_admin = false;
        }
    }
}
