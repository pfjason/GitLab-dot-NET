using System;
using Newtonsoft.Json;
using unirest_net.http;
using System.Web;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace GitLab
{
    public partial class GitLab
    {
        private List<Project> _Projects;

        public List<Project> Projects
        {
            get
            {
                if (_Projects == null)
                {
                    
                }
                return _Projects;
            }
        }
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
            public int id, namespace_id, visibility_level, creator_id, star_count, forks_count;
            public bool issues_enabled, merge_requests_enabled, wiki_enabled, snippets_enabled , builds_enabled, archived;
            public Owner owner;
            public Namespace NameSpace;
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
                List<Project> RetVal = new List<Project>();

                try
                {
                    int page = 1;

                    User Me = JsonConvert.DeserializeObject<User>(Unirest.get(_Config.APIUrl + "user?private_token=" + _Config.APIKey).header("accept", "application/json").asString().Body);
                    List<Project> projects = new List<Project>();
                    
                    do
                    {
                        HttpResponse<string> R =  Unirest.get
                                (_Config.APIUrl + "projects?per_page=100"
                                + "&page=" + page.ToString()
                                + "&private_token=" + _Config.APIKey)
                                .header("accept", "application/json")
                                .asString();

                        if (R.Code != 200)
                        {
                            Error E = JsonConvert.DeserializeObject<Error>(R.Body);
                            throw new GitLabServerErrorException(E.message);
                        }
                        else
                        {
                            dynamic Result = JsonConvert.DeserializeObject(R.Body);
                            if (Result is JArray)
                            {
                                JArray ResultArray = (JArray)Result;
                                foreach (JToken Token in ResultArray)
                                {
                                    //Console.WriteLine(Token.ToString());
                                    Project P = JsonConvert.DeserializeObject<Project>(Token.ToString());
                                    projects.Add(P);
                                }
                            }
                        }
                        page++;
                    }
                    while (projects.Count > 0 & page < 100);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RetVal;            
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
