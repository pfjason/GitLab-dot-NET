using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using unirest_net.http;
using System.Web;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GitLab
{
    public partial class GitLab
    {
        public partial class Project
        {
            class Snippet
            {
                public int id;
                public string title, file_name, expires_at, updated_at, created_at;
                public User author;

                /// <summary>
                ///  Get a list of project snippets.
                /// </summary>
                /// <param name="_Config"></param>
                /// <param name="_Project"></param>
                /// <returns></returns>
                public static List<Snippet> List(Config _Config, Project _Project)
                {
                    List<Snippet> RetVal = new List<Snippet>();

                    try
                    {
                        int page = 1;
                        List<Snippet> snippets = new List<Snippet>();

                        do
                        {
                            string URI = _Config.APIUrl +  "projects/" + _Project.id.ToString() + "/snippets" ; 
                            
                            URI += "?per_page=100" + "&page=" + page.ToString();

                            HttpResponse<string> R = Unirest.get(URI)
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
                                        Snippet S = JsonConvert.DeserializeObject<Snippet>(Token.ToString());
                                        snippets.Add(S);
                                    }
                                }
                            }
                            page++;
                            RetVal.AddRange(snippets);
                            snippets = new List<Snippet>();
                        }
                        while (snippets.Count > 0 & page < 100);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return RetVal;
                }

                /// <summary>
                /// Get a single project snippet
                /// </summary>
                /// <param name="_Config"></param>
                /// <param name="_Project"></param>
                /// <param name="_ID"></param>
                /// <returns></returns>
                public static Snippet Get(Config _Config, Project _Project, int _ID)
                {
                    Snippet RetVal;
                    try
                    {
                        string URI = _Config.APIUrl + "projects/" + _Project.id.ToString() + "/snippets/" + _ID.ToString();

                        HttpResponse<string> R = Unirest.get(URI)
                                    .header("accept", "application/json")
                                    .header("PRIVATE-TOKEN", _Config.APIKey)
                                    .asString();

                        if (R.Code < 200 | R.Code >= 300)
                        {
                            throw new GitLabServerErrorException(R.Body, R.Code);
                        }
                        else
                        {
                            RetVal = JsonConvert.DeserializeObject<Snippet>(R.Body.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return RetVal;
                }

                /// <summary>
                /// Gets the raw content of a snippet.
                /// </summary>
                /// <param name="_Config"></param>
                /// <param name="_Project">Project Descriptor object that snippet belongs to</param>
                /// <param name="_ID">Snippet ID</param>
                /// <returns></returns>
                public static Stream GetContent(Config _Config, Project _Project, int _ID)
                {
                    Stream RetVal;
                    try
                    {
                        string URI = _Config.APIUrl + "projects/" + _Project.id.ToString() + "/snippets/" + _ID.ToString() + "/raw";

                        HttpResponse<Stream> R = Unirest.get(URI)                                    
                                    .header("PRIVATE-TOKEN", _Config.APIKey)
                                    .asBinary();

                        if (R.Code < 200 | R.Code >= 300)
                        {
                            throw new GitLabServerErrorException(new StreamReader(R.Body).ReadToEnd(), R.Code);
                        }
                        else
                        {
                            RetVal = R.Body;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return RetVal;
                }

                public static Snippet Create(Config _Config, Project _Project, string _Title, string _FileName, string _Code, VisibilityLevel _VisibilityLevel)
                {
                    Snippet RetVal;
                    try
                    {
                        string URI = _Config.APIUrl + "projects/" + _Project.id.ToString() + "/snippets/"
                                + "?title=" + HttpUtility.UrlEncode(_Title)
                                + "&file_name=" + HttpUtility.UrlEncode(_FileName)
                                + "&code=" + HttpUtility.UrlEncode(_Code)
                                + "&visibility_level=" + Convert.ToInt64(_VisibilityLevel).ToString();

                        HttpResponse<string> R = Unirest.post(URI)
                                    .header("accept", "application/json")
                                    .header("PRIVATE-TOKEN", _Config.APIKey)
                                    .asString();

                        if (R.Code < 200 | R.Code >= 300)
                        {
                            throw new GitLabServerErrorException(R.Body, R.Code);
                        }
                        else
                        {
                            RetVal = JsonConvert.DeserializeObject<Snippet>(R.Body.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    return RetVal;
                }

                /// <summary>
                /// Delete snippet from a project.
                /// </summary>
                /// <param name="_Config"></param>
                /// <param name="_Project"></param>
                /// <param name="_Snippet"></param>
                /// <returns></returns>
                public static Snippet Delete(Config _Config, Project _Project, Snippet _Snippet)
                {
                    Snippet RetVal;

                    try
                    {
                        string URI = _Config.APIUrl + "projects/" + _Project.id.ToString() + "/snippets/" + _Snippet.id.ToString();

                        HttpResponse<string> R = Unirest.delete(URI)
                                    .header("accept", "application/json")
                                    .header("PRIVATE-TOKEN", _Config.APIKey)
                                    .asString();

                        if (R.Code < 200 | R.Code >= 300)
                        {
                            throw new GitLabServerErrorException(R.Body, R.Code);
                        }
                        else
                        {
                            RetVal = JsonConvert.DeserializeObject<Snippet>(R.Body.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    return RetVal;
                }

                /// <summary>
                /// Update the properties of a project snippet
                /// </summary>
                /// <param name="_Config"></param>
                /// <param name="_Project"></param>
                /// <param name="_Snippet"></param>
                /// <param name="_NewCode"></param>
                /// <param name="_NewVisibilityLevel"></param>
                public static void Update(Config _Config, Project _Project, Snippet _Snippet, string _NewCode = null, VisibilityLevel _NewVisibilityLevel = VisibilityLevel.Undefined)
                {                   
                    try
                    {
                        string URI = _Config.APIUrl + "projects/" + _Project.id.ToString() + "/snippets/" + _Snippet.id.ToString()
                                + "?title=" + HttpUtility.UrlEncode(_Snippet.title)
                                + "&file_name=" + HttpUtility.UrlEncode(_Snippet.file_name);

                        if (_NewCode != null)
                            URI += "&code=" + HttpUtility.UrlEncode(_NewCode);

                        if(_NewVisibilityLevel != VisibilityLevel.Undefined)
                            URI += "&visibility_level=" + Convert.ToInt64(_NewVisibilityLevel).ToString();

                        HttpResponse<string> R = Unirest.put(URI)
                                    .header("accept", "application/json")
                                    .header("PRIVATE-TOKEN", _Config.APIKey)
                                    .asString();

                        if (R.Code < 200 | R.Code >= 300)
                        {
                            throw new GitLabServerErrorException(R.Body, R.Code);
                        }                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
