using System;
using Newtonsoft.Json;
using unirest_net.http;
using System.Web;
using System.Collections.Generic;

namespace GitLab
{
    public partial class GitLab
    {
        /// <summary>
        /// GitLab Project Class
        /// </summary>
        /// <remarks>
        /// See https://gitlab.com/help/api/projects.md for reference
        /// </remarks>
        public  partial class Project
        {
            public string name
                , name_with_namespace
                , path
                , path_with_namespace
                , description
                , default_branch
                , import_url
                , ssh_url_to_repo
                , http_url_to_repo
                , web_url
                , created_at
                , last_activity_at
                , avatar_url;
            public string[] tag_list;
            public int id, namespace_id, visibility_level, creator_id;
            public bool issues_enabled, merge_requests_enabled, wiki_enabled, snippets_enabled , builds_enabled, archived;
            public Owner owner;
   
            /// <summary>
            /// Creates a new project
            /// </summary>
            /// <param name="_Config"></param>
            /// <param name="_Name">The name of the new project</param>
            /// <param name="_Description"> Optional Description, can be null</param>
            /// <param name="_Namespace">Namespace to create the project in</param>
            /// <param name="_VisibilityLevel">New project's visibility level</param>
            /// <returns></returns>
            public static Project Create(Config _Config, string _Name, string _Description, Namespace _Namespace, VisibilityLevel _VisibilityLevel)
            {
                Project RetVal = JsonConvert.DeserializeObject<Project>(Unirest.post(_Config.APIUrl + "projects?name=" + HttpUtility.UrlEncode(_Name)
                                        + "&namespace_id=" + _Namespace.id.ToString()
                                        + "&description=" + HttpUtility.UrlEncode(_Description)
                                        + "&visibility_level=" + Convert.ToInt64(_VisibilityLevel).ToString())
                                        .header("accept", "application/json")
                                        .header("PRIVATE-TOKEN", _Config.APIKey)
                                        .asString().Body);

                return RetVal;
            }

            /// <summary>
            /// List all projects
            /// </summary>
            /// <param name="_Config"></param>
            /// <returns></returns>
            public static List<Project> List(Config _Config)
            {                               
                throw new NotImplementedException();
            }

            /// <summary>
            /// Project Visibility Level as enum for ease of use;
            /// </summary>
            public enum VisibilityLevel
            {
                Private = 0
                , Internal = 10
                , Public = 20
            }

            /// <summary>
            /// Project owner sub-class so that owner can be parsed from JSON
            /// </summary>
            public class Owner
            {
                public int id;
                public string name, created_at;
            }
        }
    }
}
