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
                    RefreshProjects();
                }
                return _Projects;
            }
        }

        public void RefreshProjects()
        {
            _Projects = Project.List(this.CurrentConfig);
        }

        public Project CreateProject(string _Name, string _Description, Namespace _Namespace, Project.VisibilityLevel _VisibilityLevel)
        {
            Project RetVal = Project.Create(CurrentConfig, _Name, _Description, _Namespace, _VisibilityLevel);
            this.RefreshProjects();
            return RetVal;
        }

        /// <summary>
        /// Non-Static Delete Project function
        /// </summary>
        /// <param name="_Project"></param>
        public void DeleteProject(Project _Project)
        {
            GitLab.Project.Delete(CurrentConfig, _Project);
            this.RefreshProjects();
        }

        /// <summary>
        /// GitLab Project Class
        /// </summary>
        /// <remarks>
        /// See https://gitlab.com/help/api/projects.md for reference
        /// </remarks>
        public  partial class Project : object
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
                HttpResponse<string> R = Unirest.post(_Config.APIUrl + "projects?name=" + HttpUtility.UrlEncode(_Name)
                                        + "&namespace_id=" + _Namespace.id.ToString()
                                        + "&description=" + HttpUtility.UrlEncode(_Description)
                                        + "&visibility_level=" + Convert.ToInt64(_VisibilityLevel).ToString())
                                        .header("accept", "application/json")
                                        .header("PRIVATE-TOKEN", _Config.APIKey)
                                        .asString();

                if (R.Code < 200 | R.Code >= 300)
                {
                    throw new GitLabServerErrorException(R.Body, R.Code);
                }

                Project RetVal = JsonConvert.DeserializeObject<Project>(R.Body);
                return RetVal;
            }

            /// <summary>
            /// Update any project
            /// </summary>
            /// <param name="_Config">Gitlab Config Object</param>
            /// <param name="_Project">Project object</param>
            /// <returns></returns>
            public static Project Update(Config _Config, Project _Project)
            {
                HttpResponse<string> R = Unirest.put(_Config.APIUrl + "projects/"+_Project.id.ToString()
                                        +"?name=" + HttpUtility.UrlEncode(_Project.name)
                                        + "&path=" + HttpUtility.UrlEncode(_Project.path)
                                        + "&description=" + HttpUtility.UrlEncode(_Project.description)
                                        + "&default_branch=" + HttpUtility.UrlEncode(_Project.default_branch)
                                        + "&issues_enabled=" + Convert.ToInt32(_Project.issues_enabled).ToString()
                                        + "&merge_requests_enabled=" + Convert.ToInt32(_Project.merge_requests_enabled).ToString()
                                        + "&builds_enabled=" + Convert.ToInt32(_Project.builds_enabled).ToString()
                                        + "&wiki_enabled=" + Convert.ToInt32(_Project.wiki_enabled).ToString()
                                        + "&snippets_enabled=" + Convert.ToInt32(_Project.snippets_enabled).ToString()
                                        + "&visibility_level=" + Convert.ToInt64(_Project.visibility_level).ToString())
                                        .header("accept", "application/json")
                                        .header("PRIVATE-TOKEN", _Config.APIKey)
                                        .asString();

                if (R.Code < 200 | R.Code >= 300)
                {
                    throw new GitLabServerErrorException(R.Body, R.Code);
                }

                Project RetVal = JsonConvert.DeserializeObject<Project>(R.Body);
                return RetVal;
            }

            /// <summary>
            /// Deletes a project
            /// </summary>
            /// <param name="_Config"></param>
            /// <param name="_Project"></param>
            public static void Delete(Config _Config, Project _Project)
            {
                HttpResponse<string> R = Unirest.delete(_Config.APIUrl + "projects/" + _Project.id.ToString())                                        
                                        .header("accept", "application/json")
                                        .header("PRIVATE-TOKEN", _Config.APIKey)
                                        .asString();

                if (R.Code < 200 | R.Code >= 300)
                {
                    throw new GitLabServerErrorException(R.Body, R.Code);
                }
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
                    List<Project> projects = new List<Project>();
                    
                    do
                    {
                        HttpResponse<string> R =  Unirest.get
                                (_Config.APIUrl + "projects?per_page=100"
                                + "&page=" + page.ToString())
                                .header("accept", "application/json")
                                .header("PRIVATE-TOKEN", _Config.APIKey)
                                .asString();

                        if (R.Code < 200 | R.Code >= 300)
                        {
                            throw new GitLabServerErrorException(R.Body, R.Code);
                        }
                        else
                        {
                            dynamic Result = JsonConvert.DeserializeObject(R.Body);
                            if (Result is JArray)
                            {
                                JArray ResultArray = (JArray)Result;
                                foreach (JToken Token in ResultArray)
                                {
                                 //   Console.WriteLine(Token.ToString());
                                    Project P = JsonConvert.DeserializeObject<Project>(Token.ToString());
                                    projects.Add(P);
                                }
                            }
                        }
                        page++;
                        RetVal.AddRange(projects);
                        projects = new List<Project>();
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
            /// Query projects by name
            /// </summary>
            /// <param name="_Config"></param>
            /// <returns></returns>
            public static List<Project> Search(Config _Config, string Query)
            {
                List<Project> RetVal = new List<Project>();

                try
                {
                    int page = 1;
                    List<Project> projects = new List<Project>();

                    do
                    {
                        HttpResponse<string> R = Unirest.get
                                (_Config.APIUrl + "projects/search/"+HttpUtility.UrlEncode(Query)
                                +"?per_page=100"
                                + "&page=" + page.ToString())
                                .header("accept", "application/json")
                                .header("PRIVATE-TOKEN", _Config.APIKey)
                                .asString();

                        if (R.Code < 200 | R.Code >= 300)
                        {
                            throw new GitLabServerErrorException(R.Body, R.Code);
                        }
                        else
                        {
                            dynamic Result = JsonConvert.DeserializeObject(R.Body);
                            if (Result is JArray)
                            {
                                JArray ResultArray = (JArray)Result;
                                foreach (JToken Token in ResultArray)
                                {
                                    Project P = JsonConvert.DeserializeObject<Project>(Token.ToString());
                                    projects.Add(P);
                                }
                            }
                        }
                        page++;
                        RetVal.AddRange(projects);
                        projects = new List<Project>();
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

            new public string ToString()
            {
                return this.name_with_namespace;
            }
        }
    }
}
