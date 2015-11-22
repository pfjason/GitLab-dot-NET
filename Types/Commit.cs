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
        public partial class Project
        {
            public class Commit
            {
                public string id, short_id, title, author_name, author_email, created_at, message;
                public string[] parent_ids;
                public bool allow_failure;
            }
        }
    }
}
