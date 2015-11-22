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


            /// <summary>
            /// List all users that the current user can see 
            /// </summary>
            /// <param name="_Config">A GitLab.NET Configuration object</param>
            /// <returns></returns>
            public static List<User> List(Config _Config)
            {                
                List<User> RetVal = new List<User>();

                //TODO: Implement function here 
                throw new NotImplementedException();

                return RetVal;
            }

            /// <summary>
            /// Get user object by numeric ID
            /// </summary>
            /// <param name="_Config">A GitLab.NET Configuration object</param>
            /// <param name="_id">Numeric ID of the user to retrieve</param>
            /// <returns></returns>
            public static User Get(Config _Config, int _id)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Get user object for the currently logged in user
            /// </summary>
            /// <param name="_Config">A GitLab.NET Configuration object</param>
            /// <returns></returns>
            public static User Get(Config _Config)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Create a new user on the GitLab server
            /// </summary>
            /// <param name="_Config">A GitLab.NET Configuration object</param>
            /// <param name="_User">User object to create on the server</param>
            public static void Create(Config _Config, User _User)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Update a user that already exists.
            /// </summary>
            /// <param name="_Config">A GitLab.NET Configuration object</param>
            /// <param name="_User">User object to update</param>
            public static void Update(Config _Config, User _User)
            {
                throw new NotImplementedException();
            }
        }
    }
}
