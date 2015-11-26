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
            private List<Branch> _Branches = null;
            public List<Branch> Branches
            {
                get
                { 
                    if(_Branches == null)
                    {
                         //TODO: Implement get branches and store to _Branches;
                    }

                    return _Branches;
                }
            }
            /// <summary>
            /// Gitlab Project Branch object
            /// </summary>
            public class Branch
            {
                public Commit Commit;
                public string Name;
                public bool Protected;
            }

            void CreateBranch(string _name, bool _protected = false)
            {               
                throw new NotImplementedException();
            }
        }
    }
}
