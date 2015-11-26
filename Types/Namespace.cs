using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using unirest_net.http;
using System.Web;



namespace GitLab
{
    public partial class GitLab
    {
        public class Namespace : object
        {
            public int id;
            public string path, kind;

            public override string ToString()
            {
                return path;
            }

            public static List<Namespace> List(Config _Config, bool _OnlyOwned = true)
            {

                List<Namespace> RetVal = new List<Namespace>();

                try
                {
                    int page = 1;

                    User Me = JsonConvert.DeserializeObject<User>(Unirest.get(_Config.APIUrl + "user?private_token=" + _Config.APIKey).header("accept", "application/json").asString().Body);
                    List<Namespace> namespaces = new List<Namespace>();
                    
                    do
                    {
                        HttpResponse<string> R = Unirest.get
                                (_Config.APIUrl + "/namespaces?per_page=100"
                                + "&page=" + page.ToString()
                                + "&private_token=" + _Config.APIKey)
                                .header("accept", "application/json")
                                .asString();

                        if (R.Code < 200 | R.Code >= 300)
                        {
                            Error E = JsonConvert.DeserializeObject<Error>(R.Body);
                            throw new GitLabServerErrorException(E.message, R.Code);
                        }

                        namespaces = JsonConvert.DeserializeObject<List<Namespace>>(R.Body);

                       
                            foreach (Namespace NS in namespaces)
                            {
                                if ((Me.username.ToUpperInvariant() == NS.path.ToUpperInvariant()
                                        && NS.kind.ToUpperInvariant() == "USER")
                                        | NS.kind.ToUpperInvariant() == "GROUP"
                                        | !_OnlyOwned
                                        )
                                {
                                    RetVal.Add(NS);
                                }
                            }

                        page++;
                        RetVal.AddRange(namespaces);
                        namespaces = new List<Namespace>();
                    }
                    while (namespaces.Count > 0 & page < 100);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RetVal;
            }
        }
    }
}

