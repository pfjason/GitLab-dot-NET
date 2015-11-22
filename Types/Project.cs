using System;
using Newtonsoft.Json;
using unirest_net.http;
using System.Web;



namespace GitLab
{
    public partial class GitLab
    {
        public class Project
        {
            //See https://gitlab.com/help/api/projects.md for reference

            public string name, path, description, import_url, ssh_url_to_repo, http_url_to_repo, web_url;
            public int namespace_id, visibility_level;
            public bool issues_enabled, merge_requests_enabled, wiki_enabled, snippets_enabled;

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

            public enum VisibilityLevel
            {
                Private = 0
                , Internal = 10
                , Public = 20
            }
        }
    }
}
